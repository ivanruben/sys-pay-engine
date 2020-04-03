Sub invoicing()

 'Dim ws As Worksheet
 Dim lastInvauxRow As Long
 
    'identifica ultimul rand din sheet
 lastTxnRow = Sheets("txn").Range("A" & Rows.Count).End(xlUp).Row

    'Lisat merchantilor
 merchantList = Sheets("txn").Range("A4:A10000")
    'Lisat EVENT_ID-urilor
 eventList = Sheets("txn").Range("B4:B10000")
     'Lisat Scheme Product-urilor
 schemProductList = Sheets("pricing").Range("C4:C10000")
      'Lisat TrasnactionType-urilor
 transactionTypeList = Sheets("pricing").Range("I4:I10000")
    'Lisat CardsAcquired PPI-urilor
cardsAcqPPIList = Sheets("pricing").Range("N4:N10000")
    'Lisat Amounturilor-urilor
amountsList = Sheets("pricing").Range("H4:H10000")
    'Lisat CardsAcquired PPC-urilor
cardsAcqPPCList = Sheets("pricing").Range("O4:O10000")
    'Lisat CardsAcquired Charge-urilor
cardsAcqChrgList = Sheets("pricing").Range("Q4:Q10000")
 
    'Copiaza lista eventurilor  - column A
 Sheets("invaux").Range("A4:A10000") = eventList
    'Identifica ultimul rand din work shetul pricing
 lastInvauxRow = Sheets("invaux").Range("A" & Rows.Count).End(xlUp).Row
    'Copiaza lista Scheme Product  - column B
 'Sheets("invaux").Range("B4:B10000") = schemProductList
   'Copiaza lista TrasnactionType - column C
 'Sheets("invaux").Range("C4:C10000") = transactionTypeList
     'Copiaza lista CardsAcquir PPI - column E
 'Sheets("invaux").Range("E4:E10000") = cardsAcqPPIList
     'Copiaza lista PPC-urilor - column F
 'Sheets("invaux").Range("F4:F10000") = amountsList
    'Copiaza lista CardsAcquired Charge-urilor - column H
 'Sheets("invaux").Range("H4:H10000") = cardsAcqChrgList
   


 Set IndexRgn = Sheets("psegm").Range("B:B")
 Set MatchRgn = Sheets("psegm").Range("A:A")
 

 
 
 
 'Loop care sa populeze toate valorile din pricing worksheet
 For i = 4 To lastInvauxRow
    On Error Resume Next
    
    'Creeaza Invoice_event_id - coloana D
    Sheets("invaux").Range("D" & i).Value = i - 3
    'CARDS ACQUIRING
        'populeaza lista Scheme Product  - column B
    If Sheets("pricing").Range("M" & i).Value <> "" Then
    Sheets("invaux").Range("B" & i).Value = Sheets("pricing").Range("C" & i)
        'populeaza lista TrasnactionType-urilor  - column C
    If Sheets("pricing").Range("I" & i) = "Quasi Cash" Then
    Sheets("invaux").Range("C" & i).Value = "Refund"
    Else: Sheets("invaux").Range("C" & i).Value = Sheets("pricing").Range("I" & i)
    End If
        'populeaza lista CardsAcquired PPI-urilor  - column E
    Sheets("invaux").Range("E" & i).Value = Sheets("pricing").Range("N" & i)
        'populeaza lista CA Amounturilor-urilor  - column F
    Sheets("invaux").Range("F" & i).Value = Sheets("pricing").Range("H" & i)
        'populeaza lista CardsAcquired Charge-urilor - column H
    Sheets("invaux").Range("H" & i).Value = Sheets("pricing").Range("Q" & i)
        'populeaza lista PPC-urilor - column G
    If Sheets("txn").Range("D" & i).Value = "0" Or Sheets("txn").Range("D" & i).Value = "1" Or Sheets("txn").Range("D" & i).Value = "2" Then
       Sheets("invaux").Range("G" & i).Value = Sheets("pricing").Range("O" & i).Value * 100 & "%"
    Else: Sheets("invaux").Range("G" & i).Value = -Sheets("pricing").Range("O" & i).Value * 100 & "%"
    End If
    'Else: Sheets("invaux").Range("B" & i).Value = ""
    End If
        'concateneaza CardSchema+TransactioType+PPI+PPC - coloana I
        If Sheets("pricing").Range("M4").Value = "" Then
    Sheets("invaux").Range("I4").Value = "XXX"
    Sheets("invaux").Range("I" & i).Value = Sheets("invaux").Range("B" & i).Value & "=" & Sheets("invaux").Range("C" & i).Value & "/" & Sheets("invaux").Range("E" & i).Value & "!" & Sheets("invaux").Range("G" & i).Value
    Else:
    Sheets("invaux").Range("I" & i).Value = Sheets("invaux").Range("B" & i).Value & "=" & Sheets("invaux").Range("C" & i).Value & "/" & Sheets("invaux").Range("E" & i).Value & "!" & Sheets("invaux").Range("G" & i).Value
    End If
    
    
    'PREMIUM CAPTER METHODE
        'populeaza lista Scheme Product & TxnType  - column S
    If Sheets("pricing").Range("S" & i).Value <> "" Then
    Sheets("invaux").Range("S" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("J:J"), Application.WorksheetFunction.Match(Sheets("pricing").Range("S" & i).Value, Sheets("contract").Range("A:A"), 0))
        'populeaza lista Premium CapMeth PPI-urilor  - column T
    Sheets("invaux").Range("T" & i).Value = Sheets("pricing").Range("T" & i)
        'populeaza lista Premium CapMeth FUND-urilor  - column U
    Sheets("invaux").Range("U" & i).Value = Sheets("pricing").Range("H" & i)
        'populeaza lista Premium CapMeth Charge-urilor - column W
    Sheets("invaux").Range("W" & i).Value = Sheets("pricing").Range("W" & i)
        'populeaza lista PPC-urilor - column V
    If Sheets("txn").Range("D" & i).Value = "0" Or Sheets("txn").Range("D" & i).Value = "1" Or Sheets("txn").Range("D" & i).Value = "2" Then
       Sheets("invaux").Range("V" & i).Value = Sheets("pricing").Range("U" & i).Value * 100 & "%"
    Else: Sheets("invaux").Range("V" & i).Value = -Sheets("pricing").Range("U" & i).Value * 100 & "%"
    End If
    'Else: Sheets("invaux").Range("B" & i).Value = ""
    End If
    'concateneaza Premium CapMeth CardSchema+TransactioType+PPI+PPC - coloana I
     If Sheets("pricing").Range("S4").Value = "" Then
    Sheets("invaux").Range("X4").Value = "XXX"
    Sheets("invaux").Range("X" & i).Value = Sheets("invaux").Range("S" & i).Value & "=" & Sheets("invaux").Range("T" & i).Value & "/" & Sheets("invaux").Range("V" & i).Value
    Else:
    Sheets("invaux").Range("X" & i).Value = Sheets("invaux").Range("S" & i).Value & "=" & Sheets("invaux").Range("T" & i).Value & "/" & Sheets("invaux").Range("V" & i).Value
    End If
     
       'PREMIUM AUTHORISATION
        'populeaza lista Scheme Product & TxnType  - column AG
    If Sheets("pricing").Range("Y" & i).Value <> "" Then
    Sheets("invaux").Range("AG" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("J:J"), Application.WorksheetFunction.Match(Sheets("pricing").Range("Y" & i).Value, Sheets("contract").Range("A:A"), 0))
        'populeaza lista Premium Auth PPI-urilor  - column AH
    Sheets("invaux").Range("AH" & i).Value = Sheets("pricing").Range("Z" & i)
        'populeaza lista Premium Auth FUND-urilor  - column AI
    Sheets("invaux").Range("AI" & i).Value = Sheets("pricing").Range("H" & i)
        'populeaza lista Premium Auth Charge-urilor - column AK
    Sheets("invaux").Range("AK" & i).Value = Sheets("pricing").Range("AC" & i)
        'populeaza lista PPC-urilor - column AJ
    If Sheets("txn").Range("D" & i).Value = "0" Or Sheets("txn").Range("D" & i).Value = "1" Or Sheets("txn").Range("D" & i).Value = "2" Then
       Sheets("invaux").Range("AJ" & i).Value = Sheets("pricing").Range("AA" & i).Value * 100 & "%"
    Else: Sheets("invaux").Range("AJ" & i).Value = -Sheets("pricing").Range("AA" & i).Value * 100 & "%"
    End If
    'Else: Sheets("invaux").Range("B" & i).Value = ""
    End If
    'concateneaza Premium Auth CardSchema+TransactioType+PPI+PPC - coloana AL
    If Sheets("pricing").Range("Y4").Value = "" Then
    Sheets("invaux").Range("AL4").Value = "XXX"
    Sheets("invaux").Range("AL" & i).Value = Sheets("invaux").Range("AG" & i).Value & "=" & Sheets("invaux").Range("AH" & i).Value & "/" & Sheets("invaux").Range("AJ" & i).Value
    Else:
    Sheets("invaux").Range("AL" & i).Value = Sheets("invaux").Range("AG" & i).Value & "=" & Sheets("invaux").Range("AH" & i).Value & "/" & Sheets("invaux").Range("AJ" & i).Value
        End If
        
      
    'PREMIUM LOCALITY
        'populeaza lista Scheme Product & TxnType  - column AU
    If Sheets("pricing").Range("AE" & i).Value <> "" Then
    Sheets("invaux").Range("AU" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("J:J"), Application.WorksheetFunction.Match(Sheets("pricing").Range("AE" & i).Value, Sheets("contract").Range("A:A"), 0))
        'populeaza lista Premium Locality PPI-urilor  - column AV
    Sheets("invaux").Range("AV" & i).Value = Sheets("pricing").Range("AF" & i)
        'populeaza lista Premium Locality FUND-urilor  - column AW
    Sheets("invaux").Range("AW" & i).Value = Sheets("pricing").Range("H" & i)
        'populeaza lista Premium Locality Charge-urilor - column AY
    Sheets("invaux").Range("AY" & i).Value = Sheets("pricing").Range("AI" & i)
        'populeaza lista PPC-urilor - column AX
    If Sheets("txn").Range("D" & i).Value = "0" Or Sheets("txn").Range("D" & i).Value = "1" Or Sheets("txn").Range("D" & i).Value = "2" Then
       Sheets("invaux").Range("AX" & i).Value = Sheets("pricing").Range("AG" & i).Value * 100 & "%"
    Else: Sheets("invaux").Range("AX" & i).Value = -Sheets("pricing").Range("AG" & i).Value * 100 & "%"
    End If
    'Else: Sheets("invaux").Range("B" & i).Value = ""
    End If
    'concateneaza Premium Locality CardSchema+TransactioType+PPI+PPC - coloana AZ
    If Sheets("pricing").Range("AE4").Value = "" Then
    Sheets("invaux").Range("AZ4").Value = "XXX"
    Sheets("invaux").Range("AZ" & i).Value = Sheets("invaux").Range("AU" & i).Value & "=" & Sheets("invaux").Range("AV" & i).Value & "/" & Sheets("invaux").Range("AX" & i).Value
    Else:
    Sheets("invaux").Range("AZ" & i).Value = Sheets("invaux").Range("AU" & i).Value & "=" & Sheets("invaux").Range("AV" & i).Value & "/" & Sheets("invaux").Range("AX" & i).Value
        End If
        
        'CARDS PROCESSED
        'populeaza lista Scheme Product  - column BI
    If Sheets("pricing").Range("AK" & i).Value <> "" Then
    Sheets("invaux").Range("BI" & i).Value = Sheets("pricing").Range("C" & i)
        'populeaza lista TrasnactionType-urilor  - column BJ
    Sheets("invaux").Range("BJ" & i).Value = Sheets("pricing").Range("I" & i)
        'populeaza lista CardsProcessed PPI-urilor  - column BK
    Sheets("invaux").Range("BK" & i).Value = Sheets("pricing").Range("AL" & i)
        'populeaza lista CP Amounturilor-urilor  - column BL
    Sheets("invaux").Range("BL" & i).Value = Sheets("pricing").Range("H" & i)
        'populeaza lista CardsProcessed Charge-urilor - column BN
    Sheets("invaux").Range("BN" & i).Value = Sheets("pricing").Range("AO" & i)
        'populeaza lista PPC-urilor - column BM
    If Sheets("txn").Range("D" & i).Value = "0" Or Sheets("txn").Range("D" & i).Value = "1" Or Sheets("txn").Range("D" & i).Value = "2" Then
       Sheets("invaux").Range("BM" & i).Value = Sheets("pricing").Range("AM" & i).Value * 100 & "%"
    Else: Sheets("invaux").Range("BM" & i).Value = -Sheets("pricing").Range("BM" & i).Value * 100 & "%"
    End If
    'Else: Sheets("invaux").Range("B" & i).Value = ""
    End If
        'concateneaza CardSchema+TransactioType+PPI+PPC - coloana BO
        If Sheets("pricing").Range("AK4").Value = "" Then
    Sheets("invaux").Range("BO4").Value = "XXX"
    Sheets("invaux").Range("BO" & i).Value = Sheets("invaux").Range("BI" & i).Value & "=" & Sheets("invaux").Range("BJ" & i).Value & "+" & Sheets("invaux").Range("BK" & i).Value & "!" & Sheets("invaux").Range("BM" & i).Value
    Else:
    Sheets("invaux").Range("BO" & i).Value = Sheets("invaux").Range("BI" & i).Value & "=" & Sheets("invaux").Range("BJ" & i).Value & "+" & Sheets("invaux").Range("BK" & i).Value & "!" & Sheets("invaux").Range("BM" & i).Value
    End If
        
        'MISSCELANEOUS
        'populeaza lista Scheme Product  - column BY
    If Sheets("pricing").Range("AQ" & i).Value <> "" Then
    Sheets("invaux").Range("BY" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("J:J"), Application.WorksheetFunction.Match(Sheets("pricing").Range("AQ" & i).Value, Sheets("contract").Range("A:A"), 0))
        'populeaza lista Misscellaneous PPI-urilor  - column BZ
    Sheets("invaux").Range("BZ" & i).Value = Sheets("pricing").Range("AR" & i)
   
        'concateneaza CardSchema+TransactioType+PPI+PPC - coloana CA
        If Sheets("pricing").Range("AQ4").Value = "" Then
    Sheets("invaux").Range("CA4").Value = "XXX"
    Sheets("invaux").Range("CA" & i).Value = Sheets("invaux").Range("BY" & i).Value & "!" & Sheets("invaux").Range("BZ" & i).Value
    Else:
    Sheets("invaux").Range("CA" & i).Value = Sheets("invaux").Range("BY" & i).Value & "!" & Sheets("invaux").Range("BZ" & i).Value
    End If
     End If
        
      'Formateaza coloanele
    Sheets("invaux").Range("R" & i).Interior.ColorIndex = 1
    Sheets("invaux").Range("AF" & i).Interior.ColorIndex = 1
    Sheets("invaux").Range("AT" & i).Interior.ColorIndex = 1
    Sheets("invaux").Range("BH" & i).Interior.ColorIndex = 1
    Sheets("invaux").Range("BX" & i).Interior.ColorIndex = 1
    Sheets("invaux").Range("CG" & i).Interior.ColorIndex = 1

  
 Next i
 
 
 'creaza valori unice
 Set ws = ThisWorkbook.ActiveSheet
 With ws
    'creaza valori unice CARD ACWUIRED - coloana J
  Sheets("invaux").Range("I4:I" & lastInvauxRow).AdvancedFilter xlFilterCopy, , Sheets("invaux").Range("J4"), True
    'creaza valori unice PREMIUM CAPTER METHODE - coloana Y
  Sheets("invaux").Range("X4:X" & lastInvauxRow).AdvancedFilter xlFilterCopy, , Sheets("invaux").Range("Y4"), True
     'creaza valori unice PREMIUM AUTHORISATION - coloana AM
  Sheets("invaux").Range("AL4:AL" & lastInvauxRow).AdvancedFilter xlFilterCopy, , Sheets("invaux").Range("AM4"), True
   'creaza valori unice PREMIUM LOCALITY - coloana BA
  Sheets("invaux").Range("AZ4:AZ" & lastInvauxRow).AdvancedFilter xlFilterCopy, , Sheets("invaux").Range("BA4"), True
   'creaza valori unice CARDS PROCESSED - coloana BP
  Sheets("invaux").Range("BO4:BO" & lastInvauxRow).AdvancedFilter xlFilterCopy, , Sheets("invaux").Range("BP4"), True
  'creaza valori unice MISSCELANEOUS - coloana CA
  Sheets("invaux").Range("CA4:CA" & lastInvauxRow).AdvancedFilter xlFilterCopy, , Sheets("invaux").Range("CB4"), True
End With
  Set ws = Nothing
  
  
    'Identifica ultimul rand din randul de valori unice CARD ACQUIRING
 lastUniqueValue = Sheets("invaux").Range("J" & Rows.Count).End(xlUp).Row
     'Loop pt valorile unice
 For j = 4 To lastUniqueValue
    On Error Resume Next
    'CARDS ACQUIRED
    'populare unique SCHEMA =LEFT(J4,FIND("=",J4,1)-1) - coloana K
     Sheets("invaux").Range("K" & j).Value = Left(Sheets("invaux").Range("J" & j), Application.WorksheetFunction.Find("=", Sheets("invaux").Range("J" & j), 1) - 1) & "  -"
    'pupulare unique value TxnTYPE  =MID(J4,FIND("=",J4,1)+1,FIND("/",J4,1)-1-FIND("=",J4,1))- coloana L
    Sheets("invaux").Range("L" & j).Value = Mid(Sheets("invaux").Range("J" & j), Application.WorksheetFunction.Find("=", Sheets("invaux").Range("J" & j), 1) + 1, Application.WorksheetFunction.Find("/", Sheets("invaux").Range("J" & j), 1) - 1 - Application.WorksheetFunction.Find("=", Sheets("invaux").Range("J" & j), 1))
    'popularea nr of txn - coloana M
    Sheets("invaux").Range("M" & j).Value = Application.WorksheetFunction.CountIf(Sheets("invaux").Range("I4:I" & lastInvauxRow), Sheets("invaux").Range("J" & j))
    'populare unique value PPI     =MID(J4,FIND("/",J4,1)+1,FIND("!",J4,1)-1-FIND("/",J4,1))- coloana N
    Sheets("invaux").Range("N" & j).Value = Mid(Sheets("invaux").Range("J" & j), Application.WorksheetFunction.Find("/", Sheets("invaux").Range("J" & j), 1) + 1, Application.WorksheetFunction.Find("!", Sheets("invaux").Range("J" & j), 1) - 1 - Application.WorksheetFunction.Find("/", Sheets("invaux").Range("J" & j), 1))
    'FUND - =SUMIF(I:I,J4,F:F)- coloana O
    Sheets("invaux").Range("O" & j).Value = Application.WorksheetFunction.Round(Application.WorksheetFunction.SumIf(Sheets("invaux").Range("I4:I" & lastInvauxRow), Sheets("invaux").Range("J" & j), Sheets("invaux").Range("F4:F" & lastInvauxRow)), 2)
    'populare unique value PPC =RIGHT(J4,(LEN(J4)-FIND("!",J4,1)))*100&"%" - coloana P
    Sheets("invaux").Range("P" & j).Value = Right(Sheets("invaux").Range("J" & j), (Len(Sheets("invaux").Range("J" & j)) - Application.WorksheetFunction.Find("!", Sheets("invaux").Range("J" & j), 1))) * 100 & "%"
    'popularea round(CHRG amt) - coloana Q
    Sheets("invaux").Range("Q" & j).Value = Application.WorksheetFunction.Round(Application.WorksheetFunction.SumIf(Sheets("invaux").Range("I4:I" & lastInvauxRow), Sheets("invaux").Range("J" & j), Sheets("invaux").Range("H4:H" & lastInvauxRow)), 2)
    
  
Next j

 'Identifica ultimul rand din randul de valori unice PREMIUM CAPTER METHODE
 lastUniqueValuePCM = Sheets("invaux").Range("Y" & Rows.Count).End(xlUp).Row
    'Loop pt valorile unice
For j = 4 To lastUniqueValuePCM
    On Error Resume Next
   'PREMIUM CAPTER METHODE
        'populare unique SCHEMA =LEFT(Y4,FIND("=",Y4,1)-1) - coloana Z
     Sheets("invaux").Range("Z" & j).Value = Left(Sheets("invaux").Range("Y" & j), Application.WorksheetFunction.Find("=", Sheets("invaux").Range("Y" & j), 1) - 1)
        'popularea nr of txn - coloana AA
    Sheets("invaux").Range("AA" & j).Value = Application.WorksheetFunction.CountIf(Sheets("invaux").Range("X4:X" & lastInvauxRow), Sheets("invaux").Range("Y" & j))
        'populare unique value PPI  =MID(Y19,FIND("=",Y19,1)+1,FIND("/",Y19,1)-1-FIND("=",Y19,1))- coloana AB
    Sheets("invaux").Range("AB" & j).Value = Mid(Sheets("invaux").Range("Y" & j), Application.WorksheetFunction.Find("=", Sheets("invaux").Range("Y" & j), 1) + 1, Application.WorksheetFunction.Find("/", Sheets("invaux").Range("Y" & j), 1) - 1 - Application.WorksheetFunction.Find("=", Sheets("invaux").Range("Y" & j), 1))
        'FUND - =SUMIF(I:I,J4,F:F)- coloana AC
    Sheets("invaux").Range("AC" & j).Value = Application.WorksheetFunction.Round(Application.WorksheetFunction.SumIf(Sheets("invaux").Range("X4:X" & lastInvauxRow), Sheets("invaux").Range("Y" & j), Sheets("invaux").Range("U4:U" & lastInvauxRow)), 2)
        'populare unique value PPC =RIGHT(Y4,(LEN(Y4)-FIND("/",Y4,1)))*100&"%" - coloana AD
    Sheets("invaux").Range("AD" & j).Value = Right(Sheets("invaux").Range("Y" & j), (Len(Sheets("invaux").Range("Y" & j)) - Application.WorksheetFunction.Find("/", Sheets("invaux").Range("Y" & j), 1))) * 100 & "%"
        'popularea round(CHRG amt) - coloana AE
    Sheets("invaux").Range("AE" & j).Value = Application.WorksheetFunction.Round(Application.WorksheetFunction.SumIf(Sheets("invaux").Range("X4:X" & lastInvauxRow), Sheets("invaux").Range("Y" & j), Sheets("invaux").Range("W4:W" & lastInvauxRow)), 2)
    
 Next j
 
 'Identifica ultimul rand din randul de valori unice PREMIUM AUTHORISATION
 lastUniqueValuePAut = Sheets("invaux").Range("AM" & Rows.Count).End(xlUp).Row
    'Loop pt valorile unice
For j = 4 To lastUniqueValuePAut
    On Error Resume Next
   'PREMIUM AUTHORISATION
        'populare unique SCHEMA =LEFT(Y4,FIND("=",Y4,1)-1) - coloana Z
     Sheets("invaux").Range("AN" & j).Value = Left(Sheets("invaux").Range("AM" & j), Application.WorksheetFunction.Find("=", Sheets("invaux").Range("AM" & j), 1) - 1)
        'popularea nr of txn - coloana AA
    Sheets("invaux").Range("AO" & j).Value = Application.WorksheetFunction.CountIf(Sheets("invaux").Range("AL4:AL" & lastInvauxRow), Sheets("invaux").Range("AM" & j))
        'populare unique value PPI  =MID(Y19,FIND("=",Y19,1)+1,FIND("/",Y19,1)-1-FIND("=",Y19,1))- coloana AB
    Sheets("invaux").Range("AP" & j).Value = Mid(Sheets("invaux").Range("AM" & j), Application.WorksheetFunction.Find("=", Sheets("invaux").Range("AM" & j), 1) + 1, Application.WorksheetFunction.Find("/", Sheets("invaux").Range("AM" & j), 1) - 1 - Application.WorksheetFunction.Find("=", Sheets("invaux").Range("AM" & j), 1))
        'FUND - =SUMIF(I:I,J4,F:F)- coloana AC
    Sheets("invaux").Range("AQ" & j).Value = Application.WorksheetFunction.Round(Application.WorksheetFunction.SumIf(Sheets("invaux").Range("AL4:AL" & lastInvauxRow), Sheets("invaux").Range("AM" & j), Sheets("invaux").Range("AI4:AI" & lastInvauxRow)), 2)
        'populare unique value PPC =RIGHT(Y4,(LEN(Y4)-FIND("/",Y4,1)))*100&"%" - coloana AD
    Sheets("invaux").Range("AR" & j).Value = Right(Sheets("invaux").Range("AM" & j), (Len(Sheets("invaux").Range("AM" & j)) - Application.WorksheetFunction.Find("/", Sheets("invaux").Range("AM" & j), 1))) * 100 & "%"
        'popularea round(CHRG amt) - coloana AE
    Sheets("invaux").Range("AS" & j).Value = Application.WorksheetFunction.Round(Application.WorksheetFunction.SumIf(Sheets("invaux").Range("AL4:AL" & lastInvauxRow), Sheets("invaux").Range("AM" & j), Sheets("invaux").Range("AK4:KI" & lastInvauxRow)), 2)
    
 Next j
 
 
 'Identifica ultimul rand din randul de valori unice PREMIUM LOCALITY
 lastUniqueValuePLoc = Sheets("invaux").Range("BA" & Rows.Count).End(xlUp).Row
    'Loop pt valorile unice
For j = 4 To lastUniqueValuePLoc
    On Error Resume Next
   'PREMIUM LOCALITY
        'populare unique SCHEMA =LEFT(BA4,FIND("=",BA4,1)-1) - coloana BB
     Sheets("invaux").Range("BB" & j).Value = Left(Sheets("invaux").Range("BA" & j), Application.WorksheetFunction.Find("=", Sheets("invaux").Range("BA" & j), 1) - 1)
        'popularea nr of txn - coloana BC
    Sheets("invaux").Range("BC" & j).Value = Application.WorksheetFunction.CountIf(Sheets("invaux").Range("AZ4:AZ" & lastInvauxRow), Sheets("invaux").Range("BA" & j))
        'populare unique value PPI  =MID(Y19,FIND("=",Y19,1)+1,FIND("/",Y19,1)-1-FIND("=",Y19,1))- coloana BD
    Sheets("invaux").Range("BD" & j).Value = Mid(Sheets("invaux").Range("BA" & j), Application.WorksheetFunction.Find("=", Sheets("invaux").Range("BA" & j), 1) + 1, Application.WorksheetFunction.Find("/", Sheets("invaux").Range("BA" & j), 1) - 1 - Application.WorksheetFunction.Find("=", Sheets("invaux").Range("BA" & j), 1))
        'FUND - =SUMIF(I:I,J4,F:F)- coloana BE
    Sheets("invaux").Range("BE" & j).Value = Application.WorksheetFunction.Round(Application.WorksheetFunction.SumIf(Sheets("invaux").Range("AZ4:AZ" & lastInvauxRow), Sheets("invaux").Range("BA" & j), Sheets("invaux").Range("AW4:AW" & lastInvauxRow)), 2)
        'populare unique value PPC =RIGHT(BA4,(LEN(BA4)-FIND("/",BA4,1)))*100&"%" - coloana BF
    Sheets("invaux").Range("BF" & j).Value = Right(Sheets("invaux").Range("BA" & j), (Len(Sheets("invaux").Range("BA" & j)) - Application.WorksheetFunction.Find("/", Sheets("invaux").Range("BA" & j), 1))) * 100 & "%"
        'popularea round(CHRG BA) - coloana BG
    Sheets("invaux").Range("BG" & j).Value = Application.WorksheetFunction.Round(Application.WorksheetFunction.SumIf(Sheets("invaux").Range("AZ4:AZ" & lastInvauxRow), Sheets("invaux").Range("BA" & j), Sheets("invaux").Range("AY4:YI" & lastInvauxRow)), 2)
    
 Next j
 
 
  'Identifica ultimul rand din randul de valori unice CARDS PROCESSED
 lastUniqueValueCP = Sheets("invaux").Range("BP" & Rows.Count).End(xlUp).Row
     'Loop pt valorile unice
 For j = 4 To lastUniqueValueCP
    On Error Resume Next
    'CARDS PROCESSED
    'populare unique SCHEMA =LEFT(BP4,FIND("=",BP4,1)-1) - coloana BQ
     Sheets("invaux").Range("BQ" & j).Value = Left(Sheets("invaux").Range("BP" & j), Application.WorksheetFunction.Find("=", Sheets("invaux").Range("BP" & j), 1) - 1) & " - "
    ''pupulare unique value TxnTYPE  =MID(BP4,FIND("=",BP4,1)+1,FIND("/",BP4,1)-1-FIND("=",BP4,1))- coloana BR
    Sheets("invaux").Range("BR" & j).Value = Mid(Sheets("invaux").Range("BP" & j), Application.WorksheetFunction.Find("=", Sheets("invaux").Range("BP" & j), 1) + 1, Application.WorksheetFunction.Find("+", Sheets("invaux").Range("BP" & j), 1) - 1 - Application.WorksheetFunction.Find("=", Sheets("invaux").Range("BP" & j), 1))
     'popularea nr of txn - coloana BS
    Sheets("invaux").Range("BS" & j).Value = Application.WorksheetFunction.CountIf(Sheets("invaux").Range("BO4:BO" & lastInvauxRow), Sheets("invaux").Range("BP" & j))
    'populare unique value PPI     =MID(BO4,FIND("/",BO4,1)+1,FIND("!",BO4,1)-1-FIND("/",BO4,1))- coloana BT
    Sheets("invaux").Range("BT" & j).Value = Mid(Sheets("invaux").Range("BP" & j), Application.WorksheetFunction.Find("+", Sheets("invaux").Range("BP" & j), 1) + 1, Application.WorksheetFunction.Find("!", Sheets("invaux").Range("BP" & j), 1) - 1 - Application.WorksheetFunction.Find("+", Sheets("invaux").Range("BP" & j), 1))
    'FUND - =SUMIF(BO:BO,BP6,BL:BL)- coloana  BU
    Sheets("invaux").Range("BU" & j).Value = Application.WorksheetFunction.Round(Application.WorksheetFunction.SumIf(Sheets("invaux").Range("BO4:BO" & lastInvauxRow), Sheets("invaux").Range("BP" & j), Sheets("invaux").Range("BL4:BL" & lastInvauxRow)), 2)
    'populare unique value PPC =RIGHT(BO4,(LEN(BO4)-FIND("!",BO4,1)))*100&"%" - coloana BV
    Sheets("invaux").Range("BV" & j).Value = Right(Sheets("invaux").Range("BP" & j), (Len(Sheets("invaux").Range("BP" & j)) - Application.WorksheetFunction.Find("!", Sheets("invaux").Range("BP" & j), 1))) * 100 & "%"
    'popularea round(CHRG amt) - =SUMIF(BO:BO,BP4,BN:BN) - coloana BW
    Sheets("invaux").Range("BW" & j).Value = Application.WorksheetFunction.Round(Application.WorksheetFunction.SumIf(Sheets("invaux").Range("BO4:BO" & lastInvauxRow), Sheets("invaux").Range("BP" & j), Sheets("invaux").Range("BN4:BN" & lastInvauxRow)), 2)
Next j

  'Identifica ultimul rand din randul de valori unice MISSCELANEOUS
 lastUniqueValueMis = Sheets("invaux").Range("CB" & Rows.Count).End(xlUp).Row
     'Loop pt valorile unice
 For j = 4 To lastUniqueValueMis
    On Error Resume Next
    'MISSCELANEOUS
    'populare unique SCHEMA =LEFT(CB4,FIND("!",CB4,1)-1) - coloana CC
     Sheets("invaux").Range("CC" & j).Value = Left(Sheets("invaux").Range("CB" & j), Application.WorksheetFunction.Find("!", Sheets("invaux").Range("CB" & j), 1) - 1)
    'popularea nr of txn - coloana CE
    Sheets("invaux").Range("CE" & j).Value = Application.WorksheetFunction.CountIf(Sheets("invaux").Range("CA4:CA" & lastInvauxRow), Sheets("invaux").Range("CB" & j))
    'populare unique value PPI  =RIGHT(CA4,(LEN(CA4)-FIND("!",CA4,1))) - coloana CD
    Sheets("invaux").Range("CD" & j).Value = Right(Sheets("invaux").Range("CB" & j), (Len(Sheets("invaux").Range("CB" & j)) - Application.WorksheetFunction.Find("!", Sheets("invaux").Range("CB" & j), 1)))
    'popularea round(CHRG amt) - =SUMIF(CA:CA,CB4,BN:BN) - coloana CF
    Sheets("invaux").Range("CF" & j).Value = Application.WorksheetFunction.Round(Application.WorksheetFunction.SumIf(Sheets("invaux").Range("CA4:CA" & lastInvauxRow), Sheets("invaux").Range("CB" & j), Sheets("invaux").Range("BZ4:BZ" & lastInvauxRow)), 2)
Next j


     'Calculeaza toate pricing events create
     'Base Charge events
    'Sheets("pricing").Range("K3").Value = Application.Sum(Sheets("pricing").Range("K4:K1000").Value)
    'Sheets("pricing").Range("M3").Value = Application.CountA(Sheets("pricing").Range("M4:M" & i).Value)
    
 'Creeaza Invoice CardAcq Event_id
Sheets("invaux").Range("R3") = 0
For i = 4 To lastUniqueValue
On Error Resume Next
If Sheets("invaux").Range("J" & i).Value <> "XXX" Or Sheets("invaux").Range("J" & i).Value <> "" Then
Sheets("invaux").Range("R" & i).Value = Sheets("invaux").Range("R" & (i - 1)).Value + 1
End If
If Sheets("invaux").Range("J" & i).Value = "XXX" Then
Sheets("invaux").Range("R" & i).Value = 0
End If
If Sheets("invaux").Range("J" & i).Value = "" Then
Sheets("invaux").Range("R" & i).Value = Sheets("invaux").Range("R" & (i - 1)).Value
End If
Next i
maxCA = Application.WorksheetFunction.Max(Sheets("invaux").Range("R4:R" & lastInvauxRow))
Sheets("invaux").Range("R2") = maxCA
Sheets("invaux").Range("BX3") = maxCA

'Creeaza Invoice Card Processed Event_id
For i = 4 To lastUniqueValueCP
On Error Resume Next
If Sheets("invaux").Range("BP" & i).Value <> "XXX" Or Sheets("invaux").Range("BP" & i).Value <> "" Then
Sheets("invaux").Range("BX" & i).Value = Sheets("invaux").Range("BX" & (i - 1)).Value + 1
End If
If Sheets("invaux").Range("BP" & i).Value = "XXX" Then
Sheets("invaux").Range("BX" & i).Value = maxCA
End If
If Sheets("invaux").Range("BP" & i).Value = "" Then
Sheets("invaux").Range("BX" & i).Value = Sheets("invaux").Range("BX" & (i - 1)).Value
End If
Next i
maxCP = Application.WorksheetFunction.Max(Sheets("invaux").Range("BX4:BX" & lastInvauxRow))
Sheets("invaux").Range("BX2") = maxCP
Sheets("invaux").Range("AF3") = maxCP

'Creeaza Invoice Premium Capture Methode Event_id
For i = 4 To lastUniqueValuePCM
On Error Resume Next
If Sheets("invaux").Range("Y" & i).Value <> "XXX" Or Sheets("invaux").Range("Y" & i).Value <> "" Then
Sheets("invaux").Range("AF" & i).Value = Sheets("invaux").Range("AF" & (i - 1)).Value + 1
End If
If Sheets("invaux").Range("Y" & i).Value = "XXX" Then
Sheets("invaux").Range("AF" & i).Value = maxCP
End If
If Sheets("invaux").Range("Y" & i).Value = "" Then
Sheets("invaux").Range("AF" & i).Value = Sheets("invaux").Range("AF" & (i - 1)).Value
End If
Next i
maxPCM = Application.WorksheetFunction.Max(Sheets("invaux").Range("AF4:AF" & lastInvauxRow))
Sheets("invaux").Range("AF2") = maxPCM
Sheets("invaux").Range("AT3") = maxPCM

'Creeaza Invoice Premium Authorisation Event_id
For i = 4 To lastUniqueValuePAut
On Error Resume Next
If Sheets("invaux").Range("AM" & i).Value <> "XXX" Or Sheets("invaux").Range("AM" & i).Value <> "" Then
Sheets("invaux").Range("AT" & i).Value = Sheets("invaux").Range("AT" & (i - 1)).Value + 1
End If
If Sheets("invaux").Range("AM" & i).Value = "XXX" Then
Sheets("invaux").Range("AT" & i).Value = maxPCM
End If
If Sheets("invaux").Range("AM" & i).Value = "" Then
Sheets("invaux").Range("AT" & i).Value = Sheets("invaux").Range("AT" & (i - 1)).Value
End If
Next i
maxPAut = Application.WorksheetFunction.Max(Sheets("invaux").Range("AT4:AT" & lastInvauxRow))
Sheets("invaux").Range("AT2") = maxPAut
Sheets("invaux").Range("BH3") = maxPAut

'Creeaza Invoice Premium Locality Event_id
For i = 4 To lastUniqueValuePLoc
On Error Resume Next
If Sheets("invaux").Range("BA" & i).Value <> "XXX" Or Sheets("invaux").Range("BA" & i).Value <> "" Then
Sheets("invaux").Range("BH" & i).Value = Sheets("invaux").Range("BH" & (i - 1)).Value + 1
End If
If Sheets("invaux").Range("BA" & i).Value = "XXX" Then
Sheets("invaux").Range("BH" & i).Value = maxPAut
End If
If Sheets("invaux").Range("BA" & i).Value = "" Then
Sheets("invaux").Range("BH" & i).Value = Sheets("invaux").Range("BH" & (i - 1)).Value
End If
Next i
maxPL = Application.WorksheetFunction.Max(Sheets("invaux").Range("BH4:BH" & lastInvauxRow))
Sheets("invaux").Range("BH2") = maxPL
Sheets("invaux").Range("CG3") = maxPL

'Creeaza Invoice Misscellaneous Event_id
For i = 4 To lastUniqueValueMis
On Error Resume Next
If Sheets("invaux").Range("CB" & i).Value <> "XXX" Or Sheets("invaux").Range("CB" & i).Value <> "" Then
Sheets("invaux").Range("CG" & i).Value = Sheets("invaux").Range("CG" & (i - 1)).Value + 1
End If
If Sheets("invaux").Range("CB" & i).Value = "XXX" Then
Sheets("invaux").Range("CG" & i).Value = maxPL
End If
If Sheets("invaux").Range("CB" & i).Value = "" Then
Sheets("invaux").Range("CG" & i).Value = Sheets("invaux").Range("CG" & (i - 1)).Value
End If
Next i
maxMis = Application.WorksheetFunction.Max(Sheets("invaux").Range("CG4:CG" & lastInvauxRow))
Sheets("invaux").Range("CG2") = maxMis

'Sterge Invoice CardAcq Event_id inutile
Sheets("invaux").Range("R3") = 0
For i = 4 To lastUniqueValue
On Error Resume Next
If Sheets("invaux").Range("J" & i).Value = "XXX" Or Sheets("invaux").Range("J" & i).Value = "" Then
Sheets("invaux").Range("R" & i).ClearContents
End If
Next i

'Sterge Invoice Card Processed Event_id inutile
For i = 4 To lastUniqueValueCP
On Error Resume Next
If Sheets("invaux").Range("BP" & i).Value = "XXX" Or Sheets("invaux").Range("BP" & i).Value = "" Then
Sheets("invaux").Range("BX" & i).ClearContents
End If
Next i

'Sterge Invoice Premium Capture Methode Event_id inutile
For i = 4 To lastUniqueValuePCM
On Error Resume Next
If Sheets("invaux").Range("Y" & i).Value = "XXX" Or Sheets("invaux").Range("Y" & i).Value = "" Then
Sheets("invaux").Range("AF" & i).ClearContents
End If
Next i

'Sterge Invoice Premium Authorisation Event_id inutile
For i = 4 To lastUniqueValuePAut
On Error Resume Next
If Sheets("invaux").Range("AM" & i).Value = "XXX" Or Sheets("invaux").Range("AM" & i).Value = "" Then
Sheets("invaux").Range("AT" & i).ClearContents
End If
Next i

'Sterge Invoice Premium Locality Event_id inutile
For i = 4 To lastUniqueValuePLoc
On Error Resume Next
If Sheets("invaux").Range("BA" & i).Value = "XXX" Or Sheets("invaux").Range("BA" & i).Value = "" Then
Sheets("invaux").Range("BH" & i).ClearContents
End If
Next i

'Sterge Invoice Misscellaneous Event_id inutile
For i = 4 To lastUniqueValueMis
On Error Resume Next
If Sheets("invaux").Range("CB" & i).Value = "XXX" Or Sheets("invaux").Range("CB" & i).Value = "" Then
Sheets("invaux").Range("CG" & i).ClearContents
End If
Next i

End Sub
