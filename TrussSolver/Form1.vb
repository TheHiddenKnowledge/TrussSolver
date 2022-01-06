Imports MathNet.Numerics.LinearAlgebra
Imports MathNet.Numerics.Statistics
Imports Microsoft.Office.Interop

Public Class Form1
    'Determines whether the screen needs to be repainted
    Dim doPaint As Boolean
    'Stores all the points for the truss model 
    Dim Points(,) As Double
    'Stores all the node connections for each node
    Dim NCList(,) As Double
    'Both these arrays store necessary values for the member forces
    Dim forceidxlist As New ArrayList()
    Dim ForceLbls As New ArrayList()
    'Max coordinate value used for autosizing the truss model 
    Dim maxcoor As Double
    '2D array for storing free-body equations of member forces 
    Dim IntForces(,) As Double
    'Array for storing the external forces applied to truss 
    Dim AppliedForces(,) As Double
    'Arrays for storing the type of supports and the joints that have said supports
    Dim Types As New ArrayList()
    Dim Supports As New ArrayList()
    'Output matrix for the solved member forces
    Dim x As Matrix(Of Double)

    'Function for getting the member force components between two joints
    Private Function GetForce(Pos As ArrayList, Index As Integer) As ArrayList
        'Gets the position of the other joint
        Dim PositionRaw As String = Nodes.Rows.Item(Index).Cells.Item(3).Value
        Dim Force As New ArrayList()
        Dim tempp As String() = PositionRaw.Split(",")
        Dim sum As Double
        'The following loops get the normalized force components from the first joint to the second joint
        For j As Integer = 0 To tempp.Length - 1
            Dim temp As Double = Convert.ToDouble(tempp.GetValue(j)) - Pos.Item(j)
            sum += temp ^ 2
        Next
        sum ^= 0.5
        For j As Integer = 0 To tempp.Length - 1
            Dim temp As Double = Convert.ToDouble(tempp.GetValue(j)) - Pos.Item(j)
            temp /= sum
            Force.Add(temp)
        Next
        Return Force
    End Function

    'Function for debugging the input and output matrices of the truss calculator 
    Private Function Debug_Calculator(A As Matrix(Of Double), x As Matrix(Of Double), b As Matrix(Of Double))
        'These loops just print the elements of the A, x, and b matrices in an organized manner 
        For i As Integer = 0 To A.RowCount - 1
            For j As Integer = 0 To A.ColumnCount - 1
                Debug.Write(A.At(i, j))
                Debug.Write(" ")
            Next
            Debug.WriteLine("")
        Next
        For i As Integer = 0 To b.RowCount - 1
            Debug.Write(b.At(i, 0))
            Debug.Write(" ")
        Next
        Debug.WriteLine("")
        For i As Integer = 0 To x.RowCount - 1
            Debug.Write(x.At(i, 0))
            Debug.Write(" ")
        Next
        Debug.WriteLine("")
    End Function

    'Function for getting the reactions forces based on truss geometry and applied forces
    Private Function GetReactions() As Double(,)
        'Arrays for the system of equations 
        Dim A(-1, -1) As Double
        Dim b(2, 0) As Double
        Dim currentcol As Integer
        'Iterates through each row of the datagridview and creates free-body equations using moments and forces
        For i As Integer = 0 To Nodes.Rows.Count - 2
            'The radius from the first joint to the current joint 
            Dim r(1, 0) As Double
            r(0, 0) = Points(0, i) - Points(0, 0)
            r(1, 0) = Points(1, i) - Points(1, 0)
            'Only adds the following entries if the joint has a support associated with it 
            'The A and b array's sizes are updating according to the number and type of supports 
            If Supports.Contains(i) Then
                currentcol = A.GetLength(1)
                'If the support is a pin, two reaction forces are required to be solved for

                If Types(Supports.IndexOf(i)) = "Pin" Then
                    ReDim Preserve A(2, currentcol + 1)
                    A(0, currentcol) = 1
                    A(1, currentcol + 1) = 1
                    A(2, currentcol) = -r(1, 0)
                    A(2, currentcol + 1) = r(0, 0)
                End If
                'If the support is a roller, only one reaction force is required to be solved for
                If Types(Supports.IndexOf(i)) = "Roller" Then
                    ReDim Preserve A(2, currentcol)
                    A(1, currentcol) = 1
                    A(2, currentcol) = r(0, 0)
                End If
            End If
            'The applied forces are required as constants to solve the system
            b(0, 0) += AppliedForces(2 * i, 0)
            b(1, 0) += AppliedForces(2 * i + 1, 0)
            'The moment produced by the applied forces is only needed if there are more than two joints
            If Nodes.Rows.Count - 1 > 2 Then
                b(2, 0) += -AppliedForces(2 * i, 0) * r(1, 0) + AppliedForces(2 * i + 1, 0) * r(0, 0)
            End If
        Next
        'The following matrices are used with the MathNet library to solve the current system of equations
        Dim C As Matrix(Of Double) = CreateMatrix.DenseOfArray(Of Double)(A)
        Dim d As Matrix(Of Double) = CreateMatrix.DenseOfArray(Of Double)(b)
        Dim x As Matrix(Of Double) = C.Solve(d)
        'The following segment formats the code to line up with the correct joints that do have supports enabled 
        Dim answer((Nodes.Rows.Count - 1) * 2 - 1, 0) As Double
        For i As Integer = 0 To Nodes.Rows.Count - 2
            If Supports.Contains(i) Then
                If Types(Supports.IndexOf(i)) = "Pin" Then
                    answer(2 * i, 0) -= x.At(Supports.IndexOf(i), 0)
                    answer(2 * i + 1, 0) -= x.At(Supports.IndexOf(i) + 1, 0)
                End If
                If Types(Supports.IndexOf(i)) = "Roller" Then
                    answer(2 * i + 1, 0) -= x.At(Supports.IndexOf(i), 0)
                End If
            End If
        Next
        Return answer
    End Function

    'Function for displaying the numeric member forces from the truss calculation
    Private Function Display_Results()
        'First clears the items in both listboxes
        Forces.Items.Clear()
        Answer.Items.Clear()
        'For each member force in the output matrix, the corresponding listbox adds the force label and force value
        For i As Integer = 0 To x.RowCount - 1
            Forces.Items.Add(ForceLbls.Item(i))
            Answer.Items.Add(Math.Round(x.At(i, 0), 3, MidpointRounding.ToEven))
        Next
    End Function

    'Function for displaying the graphical model of the truss, including tension and compression 
    Private Function Display_Truss()
        'The truss is plotted with respect to the pixels of the form itself 
        'This scaling factor was calculated experimentally
        Dim scale As Double = Width / (10 * (maxcoor + 1))
        'This is the horizontal start offset relative to the width of the form
        Dim widthfactor As Double = Width - (Width - (Answer.Left + Answer.Width)) / 2
        'The surface handle used to create the graphics objects
        Dim surface As Graphics = CreateGraphics()
        'When this function is called the surface is first cleared
        surface.Clear(Color.DarkSalmon)
        'Array to keep track of the members that have already been plotted
        Dim plotted As New ArrayList()
        'Unique string that identifies each member
        Dim sum As String
        'This nested for loop iterates through each element of the node connections array 
        For i As Integer = 0 To NCList.GetLength(1) - 1
            For j As Integer = 0 To NCList.GetLength(0) - 1
                'This is the node that corresponds with the current column in the node connections array 
                Dim node1 As Double = Nodes.Rows.Item(i).Cells.Item(0).Value
                'This is the node that corresponds with the current row in the node connections array
                Dim node2 As Double = NCList(j, node1 - 1)
                'The index that matches the current member with the correct member force value
                Dim forceidx As Double
                'Node1 position array
                Dim p1(1) As Double
                'Node2 position array
                Dim p2(1) As Double
                'Pen used to color the graphics objects 
                Dim pen As Pen
                'Label used for the current member
                Dim lbl As String
                'Because the node connections array's size is estimated, some of the values are 0. These values must be ignored
                If node2 <> 0 Then
                    'The names of the members must be ordered from least node to greatest node (i.e. F12 or F23)
                    'This ensures that there are no duplicate identifiers (i.e. F12 vs. F21)
                    If node1 < node2 Then
                        sum = node1.ToString() + node2.ToString()
                        lbl = "F" + node1.ToString() + node2.ToString()
                    Else
                        sum = node2.ToString() + node1.ToString()
                        lbl = "F" + node2.ToString() + node1.ToString()
                    End If
                    'Adds the identifier to the member force array if it is not already in there 
                    'This also prevents duplicate indentifiers
                    If Not forceidxlist.Contains(sum) Then
                        forceidxlist.Add(sum)
                    End If
                    'Matches the member force value with the member force name
                    forceidx = forceidxlist.IndexOf(sum)
                    'Only plots members that haven't already been plotted 
                    If Not plotted.Contains(forceidx) Then
                        'The graphics methods only except PointF variables for the point values
                        Dim currentnode As PointF
                        Dim nextnode As PointF
                        'Adds the plotted member identifier to the plotted array 
                        plotted.Add(forceidx)
                        'These if/elseif/else statements get the force value for the current member using the force index
                        'They then change the pen color depending on the sign/value of the force
                        Dim force As Double = x.At(forceidx, 0)
                        If force > 0 Then
                            pen = New Pen(Color.Green, 2)
                        ElseIf force < 0 Then
                            pen = New Pen(Color.Red, 2)
                        Else
                            pen = New Pen(Color.DarkGray, 2)
                        End If
                        'All of the points for each member must be transformed from the inputted dimensions to the pixel dimensions of the form
                        For k As Integer = 0 To p1.Length - 1
                            p1(k) = Points(k, node1 - 1)
                            p2(k) = Points(k, node2 - 1)
                            currentnode.X = scale * p1(0) + widthfactor
                            currentnode.Y = -scale * p1(1) + Height / 2
                            nextnode.X = scale * p2(0) + widthfactor
                            nextnode.Y = -scale * p2(1) + Height / 2
                        Next
                        'Two circles are drawn for each joint of the member
                        surface.DrawEllipse(Pens.Blue, currentnode.X - 5, currentnode.Y - 5, 10, 10)
                        surface.DrawEllipse(Pens.Blue, nextnode.X - 5, nextnode.Y - 5, 10, 10)
                        'A label is placed at the middle of the member
                        surface.DrawString(lbl, New Font("Arial", 12), New SolidBrush(Color.Black), (nextnode.X - currentnode.X) / 2 + currentnode.X, (nextnode.Y - currentnode.Y) / 2 + currentnode.Y)
                        'The line representing the member is drawn
                        surface.DrawLine(pen, currentnode, nextnode)
                    End If
                End If
            Next
        Next
    End Function

    'Function for calculating the member forces using a system of equations based on the truss properties
    Private Sub Truss_Calculator()
        'Clears all global variables
        forceidxlist.Clear()
        Types.Clear()
        Supports.Clear()
        ForceLbls.Clear()
        ReDim Points(1, Nodes.Rows.Count - 2)
        ReDim NCList(Nodes.Rows.Count - 3, Nodes.Rows.Count - 2)
        ReDim AppliedForces((Nodes.Rows.Count - 1) * 2 - 1, 0)
        'Array used to determine the maximum coordinate
        Dim maxcoorlist((Nodes.Rows.Count - 1) * 2 - 1) As Double
        'The following variables are used to determine whether the truss is indeterminate 
        Dim members As Double
        Dim reactions As Double
        Dim joints As Double = Nodes.Rows.Count - 1
        'This loop iterates through each joint entry in the datagridview
        For Each i As DataGridViewRow In Nodes.Rows
            'Variables to store each column of the current row 
            Dim NodeLabel As String = i.Cells.Item(0).Value
            Dim NodeConnectionsRaw As String = i.Cells.Item(1).Value
            Dim Currenttype As String = i.Cells.Item(2).Value
            Dim PositionRaw As String = i.Cells.Item(3).Value
            Dim ForceRaw As String = i.Cells.Item(4).Value
            'Checks if the current row is not the last, empty row
            If Not i.IsNewRow Then
                'The following If/ElseIf statements display different error messages for different situations
                If NodeLabel Is Nothing Then
                    MessageBox.Show("Node Label(s) not filled out correctly")
                    Return
                ElseIf NodeConnectionsRaw Is Nothing Then
                    MessageBox.Show("Node Connection(s) not filled out correctly")
                    Return
                ElseIf Currenttype Is Nothing Then
                    MessageBox.Show("Type(s) not filled out correctly")
                    Return
                ElseIf PositionRaw Is Nothing Then
                    MessageBox.Show("Position(s) not filled out correctly")
                    Return
                ElseIf ForceRaw Is Nothing Then
                    MessageBox.Show("Force(s) not filled out correctly")
                    Return
                End If
                'Intermediate arrays for the columns of the current row 
                Dim NodeConnections As New ArrayList()
                Dim Position As New ArrayList()
                Dim Force As New ArrayList()
                Dim tempn As String() = NodeConnectionsRaw.Split(",")
                Dim tempp As String() = PositionRaw.Split(",")
                Dim tempf As String() = ForceRaw.Split(",")
                'Error messages for format errors 
                If tempp.Length <> 2 Then
                    MessageBox.Show("Position(s) not filled out correctly")
                    Return
                ElseIf tempf.Length <> 2 Then
                    MessageBox.Show("Force(s) not filled out correctly")
                    Return
                End If
                Dim currentnode As Integer = i.Cells.Item(0).Value
                'Adds the position coordinates to the maximum coordinate array, the points array, and the position array
                'For the current row
                For j As Integer = 0 To tempp.Length - 1
                    maxcoorlist(j + NodeLabel - 1) = MathF.Abs(tempp(j))
                    Points(j, i.Cells.Item(0).Value - 1) = tempp(j)
                    Position.Add(Convert.ToDouble(tempp(j)))
                Next
                'Adds the external force components for the current row to the corresponding force array
                For Each j As String In tempf
                    Force.Add(Convert.ToDouble(j))
                Next
                'Adds the node connections for the current row to the corresponding node connections array and the total node connections array
                For j As Integer = 0 To tempn.Length - 1
                    NodeConnections.Add(Convert.ToDouble(tempn(j)))
                    NCList(j, i.Cells.Item(0).Value - 1) = NodeConnections(j)
                Next
                'Adds the support type and node label to the correct arrays if the joint does have a support enabled
                If Currenttype <> "None" Then
                    If Currenttype = "Roller" Then
                        reactions += 1
                    ElseIf Currenttype = "Pin" Then
                        reactions += 2
                    End If
                    Supports.Add(currentnode - 1)
                    Types.Add(Currenttype)
                End If
                'Another loop iterating through the rows of the datagridview
                For Each j As DataGridViewRow In Nodes.Rows
                    'Variables for the node labels of each row for both loops
                    Dim current1 As Double = i.Cells.Item(0).Value
                    Dim current2 As Double = j.Cells.Item(0).Value
                    If j.Cells.Item(1).Value IsNot Nothing Then
                        'Unique identifiers for the current member
                        Dim sum As String
                        Dim index As Double
                        Dim lbl As String
                        'The names of the members must be ordered from least node to greatest node (i.e. F12 or F23)
                        'This ensures that there are no duplicate identifiers (i.e. F12 vs. F21)
                        If NodeConnections.Contains(current2) Then
                            If current1 < current2 Then
                                sum = current1.ToString() + current2.ToString()
                                lbl = "F" + current1.ToString() + current2.ToString()
                            Else
                                sum = current2.ToString() + current1.ToString()
                                lbl = "F" + current2.ToString() + current1.ToString()
                            End If
                            'Adds the identifier to the member force array if it is not already in there 
                            'This also prevents duplicate indentifiers
                            If Not forceidxlist.Contains(sum) Then
                                forceidxlist.Add(sum)
                                members += 1
                                ForceLbls.Add(lbl)
                            End If
                            index = forceidxlist.IndexOf(sum)
                            ReDim Preserve IntForces((Nodes.Rows.Count - 1) * 2 - 1, members - 1)
                            'Gets the normalized force in the member between the current node and the next node
                            Dim result As ArrayList = GetForce(Position, j.Index)
                            'Correctly adds the normalized member force and the current nodes external force to the correct arrays
                            For k As Integer = 0 To result.Count - 1
                                IntForces(2 * (current1 - 1) + k, index) = result(k)
                                AppliedForces(2 * (current1 - 1) + k, 0) = -Force(k)
                            Next
                        End If
                    End If
                Next
            End If
        Next
        'This displays an error message if the truss is determined to be indeterminate and therefore unsolvable
        If members + reactions > 2 * joints Then
            MessageBox.Show("Truss Indeterminate: " & members & " + " & reactions & " > 2 * " & joints)
            Return
        End If
        'Using the maximum coordinate array, the maximum coordinate value is then determined 
        maxcoor = ArrayStatistics.Maximum(maxcoorlist)
        'Calculates the reactions forces generated by each support structure 
        Dim ReactionForces = GetReactions()
        'Creates and sets an array to combine the applied forces and the reaction forces 
        Dim ExtForces((Nodes.Rows.Count - 1) * 2 - 1, 0) As Double
        For i As Integer = 0 To ExtForces.Length - 1
            ExtForces(i, 0) = ReactionForces(i, 0) + AppliedForces(i, 0)
        Next
        'The follow matrices are derived from the previously determined arrays. They are required to be matrices
        'To work with the MathNet library
        Dim A As Matrix(Of Double) = CreateMatrix.DenseOfArray(Of Double)(IntForces)
        Dim b As Matrix(Of Double) = CreateMatrix.DenseOfArray(Of Double)(ExtForces)
        'Solves the system of equations for the truss
        x = A.Solve(b)
        'Calls the functions for displaying the results and the truss model. Also enables the form graphics update
        Display_Results()
        Display_Truss()
        doPaint = True
    End Sub

    'Subroutine for painting the form when it is called to be repainted
    Private Sub Form1_Paint(sender As Object, e As EventArgs) Handles MyBase.Paint
        If doPaint Then
            Display_Truss()
        End If
    End Sub

    'Subroutine for solving the truss 
    Private Sub Calculate_Click(sender As Object, e As EventArgs) Handles Calculate.Click
        Try
            Truss_Calculator()
        Catch ex As Exception
            MessageBox.Show("Unexpected error occurred: " & vbCrLf & ex.Message)
        End Try
    End Sub
    'Subroutine that saves the inputted data to an excel file
    Private Sub SaveExcel_Click(sender As Object, e As EventArgs) Handles SaveExcel.Click
        Const WM_QUIT = &H12
        SaveFile.Filter = "Excel files (*.xlsx)|*.xlsx"
        If (SaveFile.ShowDialog() = DialogResult.OK) Then
            Dim objApp As Excel.Application = New Excel.Application
            Dim objBook As Excel.Workbook = objApp.Workbooks.Add
            Dim objSheet As Excel.Worksheet = objBook.Worksheets(1)
            objSheet.Range("A1").Value = Nodes.Rows.Count - 2
            objSheet.Range("A2").Value = "Nodes"
            objSheet.Range("B2").Value = "Connections"
            objSheet.Range("C2").Value = "Types"
            objSheet.Range("D2").Value = "Positions"
            objSheet.Range("E2").Value = "Forces"
            For i As Integer = 0 To Nodes.Rows.Count - 1
                objSheet.Range("A" & (i + 3)).Value = Nodes.Rows(i).Cells.Item(0).Value
                objSheet.Range("B" & (i + 3)).Value = Nodes.Rows(i).Cells.Item(1).Value
                objSheet.Range("C" & (i + 3)).Value = Nodes.Rows(i).Cells.Item(2).Value
                objSheet.Range("D" & (i + 3)).Value = Nodes.Rows(i).Cells.Item(3).Value
                objSheet.Range("E" & (i + 3)).Value = Nodes.Rows(i).Cells.Item(4).Value
            Next
            objBook.SaveCopyAs(SaveFile.FileName)
            objBook.Close()
            objApp.Quit()
            PostMessage(objApp.Hwnd, WM_QUIT, 0, 0)
            MessageBox.Show("File successfully saved!")
        End If
    End Sub
    'Subroutine that loads input data from an excel file
    Private Sub LoadExcel_Click(sender As Object, e As EventArgs) Handles LoadExcel.Click
        Const WM_QUIT = &H12
        OpenFile.Filter = "Excel files (*.xlsx)|*.xlsx"
        If (OpenFile.ShowDialog() = DialogResult.OK) Then
            Dim objApp As Excel.Application = New Excel.Application
            Dim objBook As Excel.Workbook = objApp.Workbooks.Open(OpenFile.FileName)
            Dim objSheet As Excel.Worksheet = objBook.Worksheets(1)
            While (Nodes.Rows.Count > 1)
                Nodes.Rows.RemoveAt(Nodes.Rows.Count - 1)
            End While
            For i As Integer = 0 To objSheet.Range("A1").Value
                Nodes.Rows.Add(objSheet.Range("A" & (i + 3)).Value, objSheet.Range("B" & (i + 3)).Value, objSheet.Range("C" & (i + 3)).Value, objSheet.Range("D" & (i + 3)).Value, objSheet.Range("E" & (i + 3)).Value)
            Next
            objBook.Close()
            objApp.Quit()
            PostMessage(objApp.Hwnd, WM_QUIT, 0, 0)
        End If
    End Sub
    Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32
    Private Sub Help_Click(sender As Object, e As EventArgs) Handles Help.Click
        System.Windows.Forms.Help.ShowHelp(ParentForm, "TrussHelp.chm")
    End Sub
End Class
