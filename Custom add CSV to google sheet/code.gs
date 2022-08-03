function myFunction() {
  
  var ss = SpreadsheetApp.getActiveSpreadsheet().getActiveSheet(); // get one active sheet
  var rows = ss.getLastRow(); // set variables
  var cell = ss.getRange(2, 4).getValue();
  var cellArr = [{}];
  var cellArr2 = [{}];
  var change;

  cellArr = cell.split(' '); // split cell content to a list
  var skuValue = cellArr[0];

  var campaingChange = Browser.inputBox(skuValue + "'s Input for Campaign:"); // input fro'm user
  var adGroupChange = Browser.inputBox(skuValue + "'s Input for Ad Group:");

  for (var i = 2; i <= rows; i++){

    // var campaingChange = "cmp1"; Easy testing
    // var adGroupChange = "ad1";

    cell = ss.getRange(i, 4).getValue();

    cellArr = cell.split(' ');
    if(cellArr[0] == skuValue){ // Remake cell!
      //FOUND NEXT SKU
      cellArr.splice(3, 1);
      cellArr.splice(0, 1);
      cellArr[0] = cellArr[0] + " - " + campaingChange + " - ";
      switch (cellArr[1]){
        case "Exac":
          change = "Exact - ";
          break;
        case "Phra":
          change = "Phrase - ";
          break;
        case "Broa":
          change = "Broad - ";
          break;
        case "Prod":
          change = "PAT - ";
          break;
        default:
          change = cellArr[1];
          break;

        }
        cellArr[1] = change;
        ss.getRange(i, 4).setValue(cellArr[0]+cellArr[1]+cellArr[2]);

    }
    else {
      // found new sku value
      skuValue = cellArr[0];
      campaingChange = Browser.inputBox(skuValue + "'s Input for Campaign:");
      adGroupChange = Browser.inputBox(skuValue + "'s Input for Ad Group:");
      cellArr.splice(3, 1);
      cellArr.splice(0, 1);
      cellArr[0] = cellArr[0] + " - " + campaingChange + " - ";
      switch (cellArr2[1]){

        case "Exac":
          change = "Exact - ";
          break;
        case "Phra":
          change = "Phrase - ";
          break;
        case "Broa":
          change = "Broad - ";
          break;
        case "Prod":
          change = "PAT - ";
          break;
        default:
          change = cellArr[1] + " - ";
          break;

        }
        cellArr[1] = change;
        ss.getRange(i, 4).setValue(cellArr[0]+cellArr[1]+cellArr[2]);
    }

    cell2 = ss.getRange(i,10).getValue(); // for add group
    cellArr2 = cell2.split(' ');

    if(cellArr2[0] == skuValue){
      cellArr2.splice(3, 1);
      cellArr2.splice(0, 1);
      cellArr2[0] = cellArr2[0] + " - " + adGroupChange + " - ";
      switch (cellArr2[1]){
        case "Exac":
          change = "Exact - ";
          break;
        case "Phra":
          change = "Phrase - ";
          break;
        case "Broa":
          change = "Broad - ";
          break;
        case "Prod":
          change = "PAT - ";
          break;
        default:
          change = cellArr2[1] + " - ";
          break;

        }
        cellArr2[1] = change;
        ss.getRange(i, 10).setValue(cellArr2[0]+cellArr2[1]+cellArr2[2]);
    }

  }

}
