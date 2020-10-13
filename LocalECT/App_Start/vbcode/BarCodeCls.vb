
'UPGRADE_ISSUE: The preceding line couldn't be parsed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="82EBB1AE-1FCB-4FEF-9E6C-8736A316F8A7"'
'VERSION()
'VERSION 1.0 CLASS
'UPGRADE_ISSUE: The preceding line couldn't be parsed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="82EBB1AE-1FCB-4FEF-9E6C-8736A316F8A7"'
'UPGRADE_ISSUE: The preceding line couldn't be parsed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="82EBB1AE-1FCB-4FEF-9E6C-8736A316F8A7"'
'BEGIN() 'True
Imports Microsoft.VisualBasic

Public Class BarCode


    Private BarTextIn As String
    Private TempString As String
    Private II As Short = 0
    Private Sum As Integer
    Private CheckSum As Short
    Private BarCodeOut As String

    Private Manufact As String
    Private answer As Short
    Private BarTextOut As String

    ' Copyright 2000 by Elfring Fonts Inc. All rights reserved. This code
    ' may not be modified or altered in any way.

    'Functions in this file:
    ' BarUPCa(Text)     -> convert 11 or 12 digits into UPC-A bar code
    ' BarUPCe(Text)     -> convert 11 or 12 digits into UPC-E bar code
    ' BarUPCcheck(Text) -> add checksum digit to 11 digit UPC-A bar code (11 -> 12 digits)

    '-----------------------------------------------------------------------------
    ' This function converts a string of 11 digits into a format compatible
    ' with Elfring Fonts Inc UPC-A bar codes. The string is checked for numeric
    ' data (all non-numeric data is ignored). Only the first 11 digits are used.
    ' The function adds the start character, scans and converts data, adds the
    ' guard bar and then adds a checksum and a stop character.
    '-----------------------------------------------------------------------------
    Public Function BarUPCa(ByRef BarTextIn As String) As String

        ' Initialize input and output strings

        BarTextOut = ""
        BarTextIn = RTrim(LTrim(BarTextIn))

        ' Throw away non-numeric data
        TempString = ""
        For Me.II = 1 To Len(BarTextIn)
            If IsNumeric(Mid(BarTextIn, II, 1)) Then
                TempString = TempString & Mid(BarTextIn, II, 1)
            End If
        Next II

        ' If not at least 11 digits, error
        If Len(TempString) < 11 Then
            TempString = "00000000000"
        End If

        ' If more than 11 digits, dump extra
        If Len(TempString) > 11 Then
            TempString = Mid(TempString, 1, 11)
        End If

        ' Calculate the checksum
        Sum = 0
        For Me.II = 1 To Len(TempString)
            If (II Mod 2) = 1 Then
                Sum = Sum + ((Asc(Mid(TempString, II, 1)) - 48) * 3)
            Else
                Sum = Sum + (Asc(Mid(TempString, II, 1)) - 48)
            End If
        Next II
        CheckSum = 10 - (Sum Mod 10)
        If CheckSum = 10 Then CheckSum = 0

        'Build ouput string, leading and trailing space for Windows rasterization bugs
        BarCodeOut = " " & Chr(Asc(Mid(TempString, 1, 1)) - 15)

        For Me.II = 2 To 6
            BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, II, 1)) + 17)
        Next II

        BarCodeOut = BarCodeOut & "|" & Mid(TempString, 7, 5)

        BarCodeOut = BarCodeOut & Chr(CheckSum + Asc("Q")) & " "

        'Return the string
        BarUPCa = BarCodeOut
    End Function


    '-----------------------------------------------------------------------------
    ' Take an 11 digit UPC-A number, figure out the checksum, and add that to the
    ' UPC code. The result is simply a 12 digit number. This is not a valid bar
    ' code string, just a valid 12 digit UPC-A number.
    '-----------------------------------------------------------------------------
    Public Function BarUPCcheck(ByRef BarTextIn As String) As String

        ' Initialize input and output strings
        BarTextOut = ""
        BarTextIn = RTrim(LTrim(BarTextIn))

        ' Throw away non-numeric data
        TempString = ""
        For Me.II = 1 To Len(BarTextIn)
            If IsNumeric(Mid(BarTextIn, II, 1)) Then
                TempString = TempString & Mid(BarTextIn, II, 1)
            End If
        Next II

        ' If not at least 11 digits, error
        If Len(TempString) < 11 Then
            TempString = "00000000000"
        End If

        ' If more than 11 digits, dump extra
        If Len(TempString) > 11 Then
            TempString = Mid(TempString, 1, 11)
        End If

        ' Calculate the checksum
        Sum = 0
        For Me.II = 1 To Len(TempString)
            If (II Mod 2) = 1 Then
                Sum = Sum + ((Asc(Mid(TempString, II, 1)) - 48) * 3)
            Else
                Sum = Sum + (Asc(Mid(TempString, II, 1)) - 48)
            End If
        Next II
        CheckSum = 10 - (Sum Mod 10)
        If CheckSum = 10 Then CheckSum = 0

        'Build ouput string
        BarCodeOut = TempString & Chr(CheckSum + Asc("0"))

        'Return the string
        BarUPCcheck = BarCodeOut
    End Function


    '-----------------------------------------------------------------------------
    ' This function converts a string of 7 or 11 digits into a format compatible
    ' with Elfring Fonts Inc UPC-E bar codes. The bar code must start with 0.
    ' The string is checked for numeric data (all non-numeric data is ignored).
    ' Only the first 11 digits are used. The function strips the zeros and
    ' converts the data into UPC-E format.
    '-----------------------------------------------------------------------------
    Public Function BarUPCe(ByRef BarTextIn As String) As String

        ' Initialize input and output strings
        BarTextOut = ""
        BarTextIn = RTrim(LTrim(BarTextIn))

        ' Throw away non-numeric data
        TempString = ""
        For Me.II = 1 To Len(BarTextIn)
            If IsNumeric(Mid(BarTextIn, II, 1)) Then
                TempString = TempString & Mid(BarTextIn, II, 1)
            End If
        Next II

        ' If we have 7 digits, we do straight conversion
        If Len(TempString) = 7 Then
            BarCodeOut = " ["
            CheckSum = Asc(Mid(TempString, 7, 1)) - 48
            BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 1, 1)) + getparity(1, CheckSum))
            BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 2, 1)) + getparity(2, CheckSum))
            BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 3, 1)) + getparity(3, CheckSum))
            BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 4, 1)) + getparity(4, CheckSum))
            BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 5, 1)) + getparity(5, CheckSum))
            BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 6, 1)) + getparity(6, CheckSum))
            'Build ouput string, leading and trailing space for Windows rasterization bugs
            BarCodeOut = BarCodeOut & "]" & Chr(CheckSum + 48)

            ' Convert 11 digit UPC-A to E
        Else
            ' If not at least 11 digits, error
            If Len(TempString) < 11 Then
                TempString = "00000000000"
            End If

            ' If more than 11 digits, dump extra
            If Len(TempString) > 11 Then
                TempString = Mid(TempString, 1, 11)
            End If

            ' If the bar code doesn't start with 0, error
            If Mid(TempString, 1, 1) <> "0" Then
                TempString = "00000000000"
            End If

            ' Calculate the checksum
            Sum = 0
            For Me.II = 1 To Len(TempString)
                If (II Mod 2) = 1 Then
                    Sum = Sum + ((Asc(Mid(TempString, II, 1)) - 48) * 3)
                Else
                    Sum = Sum + (Asc(Mid(TempString, II, 1)) - 48)
                End If
            Next II
            CheckSum = 10 - (Sum Mod 10)
            If CheckSum = 10 Then CheckSum = 0

            Manufact = Mid(TempString, 4, 3)
            BarCodeOut = " ["

            If (Manufact = "000") Or (Manufact = "100") Or (Manufact = "200") Then
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 2, 1)) + getparity(1, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 3, 1)) + getparity(2, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 9, 1)) + getparity(3, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 10, 1)) + getparity(4, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 11, 1)) + getparity(5, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 4, 1)) + getparity(6, CheckSum))
            ElseIf (Manufact = "300") Or (Manufact = "400") Or (Manufact = "500") Or (Manufact = "600") Or (Manufact = "700") Or (Manufact = "800") Or (Manufact = "900") Then
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 2, 1)) + getparity(1, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 3, 1)) + getparity(2, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 4, 1)) + getparity(3, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 10, 1)) + getparity(4, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 11, 1)) + getparity(5, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc("3") + getparity(6, CheckSum))
            ElseIf Mid(Manufact, 3, 1) = "0" Then
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 2, 1)) + getparity(1, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 3, 1)) + getparity(2, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 4, 1)) + getparity(3, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 5, 1)) + getparity(4, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 11, 1)) + getparity(5, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc("4") + getparity(6, CheckSum))
            Else
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 2, 1)) + getparity(1, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 3, 1)) + getparity(2, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 4, 1)) + getparity(3, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 5, 1)) + getparity(4, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 6, 1)) + getparity(5, CheckSum))
                BarCodeOut = BarCodeOut & Chr(Asc(Mid(TempString, 11, 1)) + getparity(6, CheckSum))
            End If

            'Build ouput string, leading and trailing space for Windows rasterization bugs
            BarCodeOut = BarCodeOut & "]" & Chr(CheckSum + 48)
        End If

        'Return the string
        BarUPCe = BarCodeOut
    End Function

    '-----------------------------------------------------------------------------
    ' This function converts a string of 11 digits into a format compatible
    ' with Elfring Fonts Inc UPC-E bar codes. The bar code must start with 0.
    ' The string is checked for numeric data (all non-numeric data is ignored).
    ' Only the first 11 digits are used. The function strips the zeros and
    ' converts the data into UPC-E format.
    '-----------------------------------------------------------------------------
    Public Function getparity(ByRef Location As Short, ByRef Check As Short) As Short

        Select Case Check
            Case 0
                If Mid("EEEOOO", Location, 1) = "O" Then
                    answer = 17
                Else
                    answer = 33
                End If
            Case 1
                If Mid("EEOEOO", Location, 1) = "O" Then
                    answer = 17
                Else
                    answer = 33
                End If
            Case 2
                If Mid("EEOOEO", Location, 1) = "O" Then
                    answer = 17
                Else
                    answer = 33
                End If
            Case 3
                If Mid("EEOOOE", Location, 1) = "O" Then
                    answer = 17
                Else
                    answer = 33
                End If
            Case 4
                If Mid("EOEEOO", Location, 1) = "O" Then
                    answer = 17
                Else
                    answer = 33
                End If
            Case 5
                If Mid("EOOEEO", Location, 1) = "O" Then
                    answer = 17
                Else
                    answer = 33
                End If
            Case 6
                If Mid("EOOOEE", Location, 1) = "O" Then
                    answer = 17
                Else
                    answer = 33
                End If
            Case 7
                If Mid("EOEOEO", Location, 1) = "O" Then
                    answer = 17
                Else
                    answer = 33
                End If
            Case 8
                If Mid("EOEOOE", Location, 1) = "O" Then
                    answer = 17
                Else
                    answer = 33
                End If
            Case 9
                If Mid("EOOEOE", Location, 1) = "O" Then
                    answer = 17
                Else
                    answer = 33
                End If
        End Select

        'Return the string
        getparity = answer
    End Function

    Public Sub PrintBarCode(ByRef strBarcode As String, ByRef strStyle As String, ByRef strArt As String, ByRef strColor As String, ByRef strSize As String, ByRef strPrice As String, ByRef strBranchID As String, Optional ByRef strQuantity As String = "")
        Dim Sleep As Object
        '*********************************************************************
        '*
        '* Name       : PrintBarCode
        '* Purpose    : Send the BarCode items to the LPT which connected to the
        '*              BarCode Printer (DataMax 4302)
        '* Returns    : True if success
        '* Created    : 20 Agust, 2003 02:45 AM by Ehab
        '*********************************************************************

        Dim iCount As Short
        Dim intPrinterFileNo As Short
        Dim strStringToPrint As String = ""

        On Error GoTo Err_Hand
        'Sleep(250)
        If strQuantity = "" Then strQuantity = "0001"
        intPrinterFileNo = FreeFile()
        FileOpen(intPrinterFileNo, "LPT1", OpenMode.Output)
        For iCount = 101 To 123
            Select Case iCount
                '            Case 110
                '                strStringToPrint = LoadResString(iCount) & strQuantity
                '            Case 111
                '                strStringToPrint = LoadResString(iCount) & strBarcode
                '            Case 116
                '                strStringToPrint = LoadResString(iCount) & "[" & strBranchID & "]"
                '            Case 118
                '                strStringToPrint = LoadResString(iCount) & strPrice
                '            Case 120
                '                strStringToPrint = LoadResString(iCount) & strStyle
                '            Case 119
                '                strStringToPrint = LoadResString(iCount) & strColor
                '            Case 121
                '                strStringToPrint = LoadResString(iCount) & strArt
                '            Case 122
                '                strStringToPrint = LoadResString(iCount) & strSize
                '            Case Else
                '                strStringToPrint = LoadResString(iCount)
            End Select

            PrintLine(intPrinterFileNo, strStringToPrint)
        Next iCount
        FileClose(intPrinterFileNo)

        Exit Sub
Err_Hand:
        MsgBox(Err.Number & vbCrLf & Err.Description, MsgBoxStyle.Critical, "BarCode")
    End Sub

    Public Function CalcCheckSum(ByRef BarTextIn As String) As String
        Dim BarTextOut As String
        Dim TempString As String
        Dim II As Short
        Dim Sum As Short
        Dim CheckSum As Short
        Dim BarCodeOut As String

        ' Initialize input and output strings
        BarTextOut = ""
        BarTextIn = RTrim(LTrim(BarTextIn))

        ' Throw away non-numeric data
        TempString = ""
        For II = 1 To Len(BarTextIn)
            If IsNumeric(Mid(BarTextIn, II, 1)) Then
                TempString = TempString & Mid(BarTextIn, II, 1)
            End If
        Next II

        ' If not at least 11 digits, error
        If Len(TempString) < 11 Then
            TempString = "00000000000"
        End If

        ' If more than 11 digits, dump extra
        If Len(TempString) > 11 Then
            TempString = Mid(TempString, 1, 11)
        End If

        ' Calculate the checksum
        Sum = 0
        For II = 1 To Len(TempString)
            If (II Mod 2) = 1 Then
                Sum = Sum + ((Asc(Mid(TempString, II, 1)) - 48) * 3)
            Else
                Sum = Sum + (Asc(Mid(TempString, II, 1)) - 48)
            End If
        Next II
        CheckSum = 10 - (Sum Mod 10)
        If CheckSum = 10 Then CheckSum = 0

        'Build ouput string
        BarCodeOut = TempString & Chr(CheckSum + Asc("0"))

        'Return the string
        CalcCheckSum = BarCodeOut
    End Function
End Class
