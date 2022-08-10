function newItem() {
    const html = HtmlService.createTemplateFromFile("page").evaluate().setTitle("Set data add-on").setHeight(480).setWidth(650);
    SpreadsheetApp.getUi().showModalDialog(html, "App");

}


function getCategory(row){
  var ss = SpreadsheetApp.getActive();
  var mainSheet = ss.getActiveSheet();
  var isBold;
  for(var i = row; i >= 5; i--){
    isBold = mainSheet.getRange(i, 1).getFontWeight();
    if(isBold == "bold"){
      return mainSheet.getRange(i, 1).getValue();
    }
  }
}


function invokeEditProperty(myData){
  
  var ui = SpreadsheetApp.getUi();
  var template = HtmlService.createTemplateFromFile('editProperty');
  template.dataFromServer = {category: myData[0], name: myData[1], value: myData[2], pyield: myData[3], row: myData[4]}
  var html = template.evaluate().setHeight(400).setWidth(350);

  ui.showModalDialog(html, 'עריכת נכס');

}


function invokeEditLoan(myData){
  
  var ui = SpreadsheetApp.getUi();
  var template = HtmlService.createTemplateFromFile('editLoan');
  template.dataFromServer = {name: myData[0], type: myData[1], amount: myData[2], interest: myData[3], period: myData[4]}
  var html = template.evaluate().setHeight(400).setWidth(350);
  
  ui.showModalDialog(html, 'עריכת הלוואה');

}


function onMyEdit(e){
  const range = e.range;
  const col = Number(range.getColumn()); //edited row and col
  const row = Number(range.getRow());
  var myData;
  Logger.log("checkpoint 0");
  
  if(range.isChecked() === true){
    const col = Number(range.getColumn());
    Logger.log("checkpoint 1");
    if(col == 9){ // on edit
      // check if loan or property

      var checkCell = SpreadsheetApp.getActiveSheet().getRange(row, 51).getValue();
      if(checkCell == 'normalLoan' || checkCell == 'ribitOnlyLoan' || checkCell == 'baloonLoan'){
        // edit loan
        lName = SpreadsheetApp.getActiveSheet().getRange(row,1).getValue(); // get values
        lType = SpreadsheetApp.getActiveSheet().getRange(row,51).getValue();
        lAmount = SpreadsheetApp.getActiveSheet().getRange(row,2).getValue();
        lInterest = SpreadsheetApp.getActiveSheet().getRange(row,8).getValue();
        lInterest = Math.abs(lInterest * 100).toFixed(2);

        // lInterest = lInterest.toString().replace("%","");
        // lInterest = parseFloat(lInterest);
        lAmount = lAmount.toString().replace(",","");
        lAmount = lAmount.toString().replace(",","");

        lAmount = Number(lAmount);
        Logger.log("editing amount: " + lAmount);
        Logger.log("editing interest asdf : " + lInterest);
        lPeriod = SpreadsheetApp.getActiveSheet().getRange(row,50).getValue();
        myData = [lName, lType, lAmount, lInterest, lPeriod];
        SpreadsheetApp.getActiveSheet().getRange(200,200).setValue(row);

        Logger.log("invoking edit loan");
        invokeEditLoan(myData);
      }
      else
      {
        // edit property
        pCategory = getCategory(row);
        pName = SpreadsheetApp.getActiveSheet().getRange(row,1).getValue(); // get values
        pValue = SpreadsheetApp.getActiveSheet().getRange(row,2).getValue();
        pYield = SpreadsheetApp.getActiveSheet().getRange(row,8).getValue();

        pYield = pYield.toString().replace("%", "");
        pYield = Number(pYield);
        pYield = Number(pYield) * 100;

        pValue = pValue.toString().replace(",","");
        pValue = pValue.toString().replace(",","");

        lAmpValueount = Number(pValue);

        myData = [pCategory, pName, pValue, pYield];
        SpreadsheetApp.getActiveSheet().getRange(200,200).setValue(row);
        Logger.log(myData);

        Logger.log("invoking edit property");
        invokeEditProperty(myData);
      }
      range.uncheck();
    }
    else if(col == 10){ //on delete

      var isLoan = SpreadsheetApp.getActiveSheet().getRange(row, 51).getValue();
      if (isLoan == 'normalLoan' || isLoan == 'ribitOnlyLoan' || isLoan == 'baloonLoan'){
        // delete loan
        Logger.log("deleting row: " + row);
        SpreadsheetApp.getActiveSheet().deleteRow(row);
        var loansNum = countLoans();
        var loanDetailsRow = row + 5 + loansNum;
        //delete loan details
        Logger.log("deleting row: " + loanDetailsRow + " ("+row+ " " + loansNum+ " )");
        SpreadsheetApp.getActiveSheet().deleteRow(loanDetailsRow);
      }
      else{
        Logger.log("deleting row " + row);
        SpreadsheetApp.getActiveSheet().deleteRow(row);
        
      }
      updateAmounts();
    }
  }

}


function insertEdits(row){
  SpreadsheetApp.getActiveSheet().getRange(row, 9).insertCheckboxes();
  SpreadsheetApp.getActiveSheet().getRange(row, 10).insertCheckboxes();

}


function setProperty(myValues){

  var assetCategory = myValues[0];
  var assetName = myValues[1];
  var assetValue = myValues[2];
  var assetYield = myValues[3];

  assetYield = assetYield.toString().replace("%","");
  assetYield = Number(assetYield);
  assetValue = assetValue.toString().replace(",","");
  assetValue = assetValue.toString().replace(",","");
  assetValue = Number(assetValue);

  var ss = SpreadsheetApp.getActive();

  var mainSheet = ss.getActiveSheet();
  var calcSheet = ss.getSheetByName("מחשבוני עזר");

  var i = 4;
  var foundCat = false;

  var cellValue = mainSheet.getRange(i, 1).getValue();


  while(cellValue != 'סה"כ נכסים'){
    if(cellValue == assetCategory) {
        foundCat = true;
        break;
    }
    Logger.log(cellValue);
    i = i + 1;
    cellValue = mainSheet.getRange(i, 1).getValue();
    if(i == 200){
      Logger.log("Error in while, setProperty");
      break;
    }
  }

  if (!foundCat){
    mainSheet.insertRowBefore(i); // insert category field
    var copyFrom = mainSheet.getRange("A100:1080");
    var copyTo = mainSheet.getRange(i,1,1,8);
    copyTo.setBackgroundColor(copyFrom.getBackgroundColor());
    mainSheet.getRange(i, 1).setValue(assetCategory);
    mainSheet.getRange(i, 1).setFontWeight("bold");
    mainSheet.insertRowAfter(i); // insert normal field
    i = i + 1;
    insertEdits(i);
    var copyFrom = mainSheet.getRange("A100:1080");
    var copyTo = mainSheet.getRange(i,1,1,8);
    copyTo.setFontWeight("normal");
    copyTo.setBackgroundColor(copyFrom.getBackgroundColor());

  }
  else {
    i = i +1;
    cellValue = mainSheet.getRange(i, 1).getValue();
    var cellFontWeight = mainSheet.getRange(i,1).getFontWeight();
    while(cellValue != 'סה"כ נכסים'){
      if(cellFontWeight == "bold"){
        break;
      }
      i = i + 1;
      cellValue = mainSheet.getRange(i, 1).getValue();
      cellFontWeight = mainSheet.getRange(i,1).getFontWeight();
      if(i == 200){
        Logger.log("Error in while, setProperty (2)");
        break;
    }
    }
    mainSheet.insertRowBefore(i); // insert normal field
    var copyFrom = mainSheet.getRange("A100:1080");
    var copyTo = mainSheet.getRange(i,1,1,8);
    copyTo.setBackgroundColor(copyFrom.getBackgroundColor());
    insertEdits(i);
    mainSheet.getRange(i,1,1,8).setFontWeight("normal");
  }

  
  mainSheet.getRange(i, 1).setValue(assetName);

  mainSheet.getRange(i, 2).setValue(assetValue); // asset value and yield
  mainSheet.getRange(i, 8).setValue(assetYield+"%");
  var next = assetValue + (assetValue * (assetYield/100));

  mainSheet.getRange(i, 3).setValue(next);
  var next = next + (next * (assetYield/100));
  mainSheet.getRange(i, 4).setValue(next);
  var next = next + (next * (assetYield/100));
  mainSheet.getRange(i, 5).setValue(next);
  var next = next + (next * (assetYield/100));
  mainSheet.getRange(i, 6).setValue(next);
  var next = next + (next * (assetYield/100));
  mainSheet.getRange(i, 7).setValue(next);

  var output = HtmlService.createHtmlOutput('<script>google.script.host.close();</script>');
  SpreadsheetApp.getUi().showModalDialog(output, 'Loading...');
  
  updateAmounts();

}


function gsUpdateProperty(myValues){

  var ss = SpreadsheetApp.getActiveSheet();
  Logger.log(myValues);
  var assetCategory = myValues[0];
  var assetName = myValues[1];
  var assetValue = myValues[2];
  var assetYield = myValues[3];
  var assetRow = ss.getRange(200,200).getValue();

  assetYield = assetYield.toString().replace("%","");
  assetYield = Number(assetYield);
  assetValue = assetValue.toString().replace(",","");
  assetValue = assetValue.toString().replace(",","");

  assetValue = Number(assetValue);

  ss.getRange(assetRow, 1).setValue(assetName);
  ss.getRange(assetRow, 2).setValue(assetValue);
  ss.getRange(assetRow, 8).setValue(assetYield+"%");
  var next = assetValue + (assetValue * (assetYield/100));

  ss.getRange(assetRow, 3).setValue(next);
  var next = next + (next * (assetYield/100));
  ss.getRange(assetRow, 4).setValue(next);
  var next = next + (next * (assetYield/100));
  ss.getRange(assetRow, 5).setValue(next);
  var next = next + (next * (assetYield/100));
  ss.getRange(assetRow, 6).setValue(next);
  var next = next + (next * (assetYield/100));
  ss.getRange(assetRow, 7).setValue(next);

  var output = HtmlService.createHtmlOutput('<script>google.script.host.close();</script>');
  SpreadsheetApp.getUi().showModalDialog(output, 'Loading...');

  updateAmounts();

}


function setLoan(myValues){

  var loanName = myValues[0];
  var loanType = myValues[1];
  var loanAmount = myValues[2];
  var loanInterest = myValues[3];
  var loanPeriod = myValues[4];

  loanInterest = loanInterest.toString().replace("%","");
  loanInterest = Number(loanInterest);

  loanAmount = loanAmount.toString().replace(",","");
  loanAmount = loanAmount.toString().replace(",","");

  loanAmount = Number(loanAmount);

  var mainSheet = SpreadsheetApp.getActiveSheet();

  var i = 6;
  cellValue = mainSheet.getRange(i, 1).getValue(); // look for end of loans
  while (cellValue != 'סה"כ התחייבויות') {
    i = i + 1;
    cellValue = mainSheet.getRange(i, 1).getValue();
    if(i == 200){
      Logger.log("Error in while, setLoan");
      break;
    }
  }

  mainSheet.insertRowAfter(i - 1); // insert new loan row

  var copyFrom = mainSheet.getRange("A100:H100");
  var copyTo = mainSheet.getRange(i,1,1,8);

  copyTo.setFontWeight("normal");
  copyTo.setBackgroundColor(copyFrom.getBackgroundColor());

  insertEdits(i);

  Logger.log("i: " + i);
  var loansNum = countLoans();

  var loanDetailsRow = i + 5 + loansNum;
  Logger.log("loan details: i: " + i + "loansNum: " +loansNum + "loanDetailsRow: " + loanDetailsRow + "" );
  Logger.log("inserting row before: "+loanDetailsRow);
  mainSheet.insertRowBefore(loanDetailsRow); // insert new loan details row

  copyTo = mainSheet.getRange(loanDetailsRow,1,1,8);
  copyTo.setFontWeight("normal");
  copyTo.setBackgroundColor(copyFrom.getBackgroundColor());

  mainSheet.getRange(i, 1).setValue(loanName); // populate loan rows
  mainSheet.getRange(i, 2).setValue(loanAmount);
  mainSheet.getRange(i, 8).setValue(loanInterest);
  mainSheet.getRange(i, 50).setValue(loanPeriod);
  mainSheet.getRange(i, 51).setValue(loanType);

  mainSheet.getRange(loanDetailsRow, 1).setValue(loanName); // populate loan details rows
  mainSheet.getRange(loanDetailsRow, 2).setValue(loanAmount);
  mainSheet.getRange(loanDetailsRow, 3).setValue(loanType);
  mainSheet.getRange(loanDetailsRow, 6).setValue(loanInterest + "%");
  mainSheet.getRange(loanDetailsRow, 7).setValue(loanPeriod);

  var output = HtmlService.createHtmlOutput('<script>google.script.host.close();</script>');
  SpreadsheetApp.getUi().showModalDialog(output, 'Loading...');

  updateLoanRow(i, loanDetailsRow);

  updateAmounts();
  
}


function gsUpdateLoan(myValues){

  var loanName = myValues[0];
  var loanType = myValues[1];
  var loanAmount = myValues[2];
  var loanInterest = myValues[3];
  var loanPeriod = myValues[4];

  Logger.log("amount: " + loanAmount);
  loanInterest = loanInterest.toString().replace("%","");
  loanInterest = parseInt(loanInterest);
  Logger.log("loan interest is: " + loanInterest);

  loanAmount = loanAmount.replace(',', '');
  loanAmount = loanAmount.replace(',', '');
  loanAmount = Number(loanAmount);

  Logger.log("after amount: " + loanAmount);

  var ss = SpreadsheetApp.getActiveSheet();
  var loanRow = ss.getRange(200, 200).getValue();

  ss.getRange(loanRow, 1).setValue(loanName);
  ss.getRange(loanRow, 2).setValue(loanAmount);
  ss.getRange(loanRow, 8).setValue(loanInterest);
  ss.getRange(loanRow, 50).setValue(loanPeriod);
  ss.getRange(loanRow, 51).setValue(loanType);

  ss.getRange(loanRow + 5 + countLoans(), 1).setValue(loanName);
  ss.getRange(loanRow + 5 + countLoans(), 2).setValue(loanAmount);
  ss.getRange(loanRow + 5 + countLoans(), 3).setValue(loanType);
  ss.getRange(loanRow + 5 + countLoans(), 6).setValue(loanInterest + "%");
  ss.getRange(loanRow + 5 + countLoans(), 7).setValue(loanPeriod);

  var output = HtmlService.createHtmlOutput('<script>google.script.host.close();</script>');
  SpreadsheetApp.getUi().showModalDialog(output, 'Loading...');

  updateLoanRow(loanRow);
  updateAmounts();


}


function updateAmounts(){
  
  var ss = SpreadsheetApp.getActive();
  var mainSheet = ss.getActiveSheet();

  var i = 5;

  var boldRow = i;
  var boldSum = 0, total = 0, boldSumA = 0, boldSumB = 0, boldSumC = 0, boldSumD = 0, boldSumE = 0, totalA = 0, totalB = 0, totalC = 0, totalD = 0, totalE = 0;

  var cellValue = mainSheet.getRange(i, 1).getValue();
  var cellFont = mainSheet.getRange(i, 1).getFontWeight();
  var nextCellFont = mainSheet.getRange(i + 1, 1).getFontWeight();

  while(cellValue != 'סה"כ נכסים'){

    if(cellFont == "bold" && nextCellFont == "bold"){
        mainSheet.getRange(i, 2).setValue(0);

        mainSheet.getRange(i, 3).setValue(0);
        mainSheet.getRange(i, 4).setValue(0);
        mainSheet.getRange(i, 5).setValue(0);
        mainSheet.getRange(i, 6).setValue(0);
        mainSheet.getRange(i, 7).setValue(0);
    }
    else if(cellFont == "bold"){
      if(i != 5){
        mainSheet.getRange(boldRow, 2).setValue(boldSum);

        mainSheet.getRange(boldRow, 3).setValue(boldSumA);
        mainSheet.getRange(boldRow, 4).setValue(boldSumB);
        mainSheet.getRange(boldRow, 5).setValue(boldSumC);
        mainSheet.getRange(boldRow, 6).setValue(boldSumD);
        mainSheet.getRange(boldRow, 7).setValue(boldSumE);

        mainSheet.getRange(boldRow, 2).setFontWeight("bold");

        mainSheet.getRange(boldRow, 3).setFontWeight("bold");
        mainSheet.getRange(boldRow, 4).setFontWeight("bold");
        mainSheet.getRange(boldRow, 5).setFontWeight("bold");
        mainSheet.getRange(boldRow, 6).setFontWeight("bold");
        mainSheet.getRange(boldRow, 7).setFontWeight("bold");

      }
    // else{
    //     mainSheet.getRange(i, 3).setValue(0);
    //     mainSheet.getRange(i, 4).setValue(0);
    //     mainSheet.getRange(i, 5).setValue(0);
    //     mainSheet.getRange(i, 6).setValue(0);
    //     mainSheet.getRange(i, 7).setValue(0);
    // }
      boldRow = i;

      total = total + boldSum;
      totalA = totalA + boldSumA;
      totalB = totalB + boldSumB;
      totalC = totalC + boldSumC;
      totalD = totalD + boldSumD;
      totalE = totalE + boldSumE;

      boldSum = 0;

      boldSumA = 0;
      boldSumB = 0;
      boldSumC = 0;
      boldSumD = 0;
      boldSumE = 0;

    }
    else{
      boldSum = boldSum + Number(mainSheet.getRange(i, 2).getValue());

      boldSumA = boldSumA + Number(mainSheet.getRange(i, 3).getValue());
      boldSumB = boldSumB + Number(mainSheet.getRange(i, 4).getValue());
      boldSumC = boldSumC + Number(mainSheet.getRange(i, 5).getValue());
      boldSumD = boldSumD + Number(mainSheet.getRange(i, 6).getValue());
      boldSumE = boldSumE + Number(mainSheet.getRange(i, 7).getValue());
    }
    i = i + 1;
    cellValue = mainSheet.getRange(i, 1).getValue();
    cellFont = mainSheet.getRange(i, 1).getFontWeight();
    nextCellFont = mainSheet.getRange(i + 1, 1).getFontWeight();
    if(i == 200){
      Logger.log("Error in while, updateAmounts");
      break;
    }
  }

  total = total + boldSum;

  totalA = totalA + boldSumA;
  totalB = totalB + boldSumB;
  totalC = totalC + boldSumC;
  totalD = totalD + boldSumD;
  totalE = totalE + boldSumE;

  mainSheet.getRange(boldRow, 2).setValue(boldSum);

  mainSheet.getRange(boldRow, 3).setValue(boldSumA);
  mainSheet.getRange(boldRow, 4).setValue(boldSumB);
  mainSheet.getRange(boldRow, 5).setValue(boldSumC);
  mainSheet.getRange(boldRow, 6).setValue(boldSumD);
  mainSheet.getRange(boldRow, 7).setValue(boldSumE);

  mainSheet.getRange(boldRow, 2).setFontWeight("bold");

  mainSheet.getRange(boldRow, 3).setFontWeight("bold");
  mainSheet.getRange(boldRow, 4).setFontWeight("bold");
  mainSheet.getRange(boldRow, 5).setFontWeight("bold");
  mainSheet.getRange(boldRow, 6).setFontWeight("bold");
  mainSheet.getRange(boldRow, 7).setFontWeight("bold");

  mainSheet.getRange(i, 2).setValue(total);

  mainSheet.getRange(i, 3).setValue(totalA);
  mainSheet.getRange(i, 4).setValue(totalB);
  mainSheet.getRange(i, 5).setValue(totalC);
  mainSheet.getRange(i, 6).setValue(totalD);
  mainSheet.getRange(i, 7).setValue(totalE);

  var totalR = total;
  var totalRa = totalA;
  var totalRb = totalB;
  var totalRc = totalC;
  var totalRd = totalD;
  var totalRe = totalE;

  // update loans
  
  total = 0;
  totalA = 0;
  totalB = 0;
  totalC = 0;
  totalD = 0;
  totalE = 0;
  
  i = 5;
  while(mainSheet.getRange(i, 1).getValue() != 'התחייבויות')
  {
    i = i + 1;
    if(i == 200){
      Logger.log("error with counter, updateAmounts");
    }
  }
  i = i + 1;
  checkIfNoLoansCounter = i;
  while(mainSheet.getRange(i, 1).getValue() != 'סה"כ התחייבויות'){
    total = total + mainSheet.getRange(i, 2).getValue();

    totalA = totalA + mainSheet.getRange(i, 3).getValue();
    totalB = totalB + mainSheet.getRange(i, 4).getValue();
    totalC = totalC + mainSheet.getRange(i, 5).getValue();
    totalD = totalD + mainSheet.getRange(i, 6).getValue();
    totalE = totalE + mainSheet.getRange(i, 7).getValue();
    i = i + 1;

    if(i == 200){
      Logger.log("error with counter, updateAmounts (2)");
    }
  }
  
  mainSheet.getRange(i, 2).setValue(total);

  mainSheet.getRange(i, 3).setValue(totalA);
  mainSheet.getRange(i, 4).setValue(totalB);
  mainSheet.getRange(i, 5).setValue(totalC);
  mainSheet.getRange(i, 6).setValue(totalD);
  mainSheet.getRange(i, 7).setValue(totalE);

  var loansNum = countLoans(i + 6);

  var loanDetailsRow = i + 5 + loansNum;

  mainSheet.getRange(loanDetailsRow, 2).setValue(total);

  totalR = totalR - total;
  totalRa = totalRa - totalA;
  totalRb = totalRb - totalB;
  totalRc = totalRc - totalC;
  totalRd = totalRd - totalD;
  totalRe = totalRe - totalE;

  mainSheet.getRange(i + 1, 2).setValue(totalR);

  mainSheet.getRange(i + 1, 3).setValue(totalRa);
  mainSheet.getRange(i + 1, 4).setValue(totalRb);
  mainSheet.getRange(i + 1, 5).setValue(totalRc);
  mainSheet.getRange(i + 1, 6).setValue(totalRd);
  mainSheet.getRange(i + 1, 7).setValue(totalRe);

  var totalReturns = 0;
  var x = loanDetailsRow - loansNum;

  while(mainSheet.getRange(x, 1).getValue() != 'סה"כ התחייבויות'){
    totalReturns = totalReturns + mainSheet.getRange(x, 4).getValue();
    x = x + 1;
    if(x == 200){
      Logger.log("error with counter, updateAmounts (3)");
    }
  }
  Logger.log("total returns: " + totalReturns);
  mainSheet.getRange(loanDetailsRow, 4).setValue(totalReturns);

}


function updateLoanRow(row){
  
  var loansNum = countLoans();

  var loanDetailsRow = row + 5 + loansNum;
  Logger.log(row + "'s detais is at " + loanDetailsRow);
  var ss = SpreadsheetApp.getActive();

  var mainSheet = ss.getActiveSheet();
  var calcSheet = ss.getSheetByName("מחשבוני עזר");

  var loanName = mainSheet.getRange(row, 1).getValue();
  var loanAmount = mainSheet.getRange(row, 2).getValue();
  var loanInterest = mainSheet.getRange(row, 8).getValue();
  var loanPeriod = mainSheet.getRange(row, 50).getValue();
  var loanType = mainSheet.getRange(row, 51).getValue();

  loanInterest = loanInterest.toString().replace("%","");
  loanInterest = Number(loanInterest);
  
  var yearA, yearB, yearC, yearD, yearE; // loan years

  var i = Number(row);

  if(loanType == "normalLoan"){

    Logger.log("Checkpoint 2");

    calcSheet.getRange(34,1).setValue(Number(loanAmount)) // normal loan
    calcSheet.getRange(37,2).setValue(Number(loanAmount)) // normal loan

    Logger.log("setting period to: " + loanPeriod);
    calcSheet.getRange(34,3).setValue(Number(loanPeriod)) // normal loan
    calcSheet.getRange(34,5).setValue(Number(loanInterest)/100) // normal loan


    yearA = calcSheet.getRange(113,2).getValue();
    yearB = calcSheet.getRange(113,3).getValue();
    yearC = calcSheet.getRange(113,4).getValue();
    yearD = calcSheet.getRange(113,5).getValue();
    yearE = calcSheet.getRange(113,6).getValue();

    mainSheet.getRange(i, 3).setValue(yearA);
    mainSheet.getRange(i, 4).setValue(yearB);
    mainSheet.getRange(i, 5).setValue(yearC);
    mainSheet.getRange(i, 6).setValue(yearD);
    mainSheet.getRange(i, 7).setValue(yearE);

    mainSheet.getRange(i, 8).setValue(loanInterest + "%");

    Logger.log("setting " + loanDetailsRow + " to הלוואה רגילה");
    mainSheet.getRange(loanDetailsRow, 3).setValue("הלוואה רגילה");

    monthlyReturn = calcSheet.getRange(34, 6).getValue();
    mainSheet.getRange(loanDetailsRow, 4).setValue(monthlyReturn);

  }
  else if (loanType == "ribitOnlyLoan"){

    mainSheet.getRange(i, 2).setValue(loanAmount);
    mainSheet.getRange(i, 3).setValue(loanAmount);
    mainSheet.getRange(i, 4).setValue(loanAmount);
    mainSheet.getRange(i, 5).setValue(loanAmount);
    mainSheet.getRange(i, 6).setValue(loanAmount);
    mainSheet.getRange(i, 7).setValue(loanAmount);

    mainSheet.getRange(i, 8).setValue(loanInterest + "%");

    mainSheet.getRange(loanDetailsRow, 3).setValue("הלוואת ריבית בלבד");

    monthlyReturn = (loanAmount * (loanInterest / 100)) / 12;
    mainSheet.getRange(loanDetailsRow, 4).setValue(monthlyReturn);

  }
  else if (loanType == "baloonLoan"){

    mainSheet.getRange(i, 2).setValue(loanAmount); // asset value and yield
    mainSheet.getRange(i, 8).setValue(loanInterest+"%");
    var next = loanAmount + (loanAmount * (loanInterest/100));

    mainSheet.getRange(i, 3).setValue(next);
    next = next + (next * (loanInterest/100));
    mainSheet.getRange(i, 4).setValue(next);
    next = next + (next * (loanInterest/100));
    mainSheet.getRange(i, 5).setValue(next);
    next = next + (next * (loanInterest/100));
    mainSheet.getRange(i, 6).setValue(next);
    next = next + (next * (loanInterest/100));
    mainSheet.getRange(i, 7).setValue(next);

    mainSheet.getRange(loanDetailsRow, 3).setValue("הלוואת בלון");

    mainSheet.getRange(loanDetailsRow, 4).setValue(0);

  }

}


function countLoans(){

  var ss = SpreadsheetApp.getActiveSheet();
  var i = 5;
  while(ss.getRange(i, 1).getValue() != 'התחייבויות'){
    i = i + 1;
  }
  i = i + 1;
  var counter = 0;
  while (ss.getRange(i, 1).getValue() != 'סה"כ התחייבויות'){
    counter = counter + 1;
    if (counter == 100){
      Logger.log("counting loans error");
      return "error";
    }
    i = i + 1;
  }
  return counter;

}

function Initiate_Sheet(){

  const ss = SpreadsheetApp.getActive();
  triggers = ScriptApp.getProjectTriggers();
  
  try{
  Logger.log(triggers[0].getEventType());
  }
  catch(e){
      ScriptApp.newTrigger('onMyEdit')
    .forSpreadsheet(ss)
    .onEdit()
    .create();
  triggers = ScriptApp.getProjectTriggers();
  Logger.log(e);
  }

}
