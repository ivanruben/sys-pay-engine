Attribute VB_Name = "Module2"
Sub regreshPricing()
Sheets("pricing").Range("A4:A10000").EntireRow.Delete
Sheets("invaux").Range("A4:A10000").EntireRow.Delete

Sheets("pricing").Range("K3").ClearContents
Sheets("pricing").Range("M3").ClearContents


End Sub
