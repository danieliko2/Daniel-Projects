function myFunction() {

  SpreadsheetApp.getActiveSpreadsheet().toast("Starting..","",-1);

  var ss = SpreadsheetApp.openById("1OirCGjopUu81qrvqJnyIhhi-RIzKfdI07yrge1n0EiU"); // main spreadsheet
  var dashboard = ss.getSheetByName("Dashboard");
  var dataSheet = ss.getSheetByName("Data");
  var len = dataSheet.getLastRow();

  var company = dashboard.getRange(3, 2).getValue(); // get variables from dashboard
  var sheetName = dashboard.getRange(3, 3).getValue();
  var productName = dashboard.getRange(3, 4).getValue();
  var colorColumn = dashboard.getRange(3, 5).getValue().toUpperCase().charCodeAt(0) - 64;
  var pages = dashboard.getRange(3, 6).getValue();
  var version = dashboard.getRange(3, 7).getValue();
  var templateID = dashboard.getRange(3, 8).getValue();
  
  var date = Utilities.formatDate(new Date(), "GMT+3", "dd/MM/yyyy"); // today's date

  var sheet = ss.getSheetByName(sheetName); // get working sheet

  var datalen = dataSheet.getLastRow(); // dataSheet length

  for(var i = 2; i <= datalen; i++){ // look for company root folder
    let cell = dataSheet.getRange(i, 1).getValue();
    if(cell == company){
      rootfolderID = dataSheet.getRange(i, 2).getValue();
      break;
    }
    if(i == datalen){ // in case company not found in datasheet.
      SpreadsheetApp.getUi().alert("Error with datasheet - not found company: " + company);
      Logger.log("Error with datasheet - not found company: " + company)
      return;
    }
  }

  var folder;
  var rootfolder = DriveApp.getFolderById(rootfolderID); // check if sheet folder exists
  var found = false;
  
  var rootfolders = rootfolder.getFolders();
  while(rootfolders.hasNext()){
    folder = rootfolders.next();
    Logger.log(folder.getName());
    if(folder.getName() ==  sheetName){
      found = true;
      break;
    }
  }
  if(!found){ // create folder if not found
    folder = rootfolder.createFolder(sheetName);
  }

  //work in sheetName folder:
  Logger.log("checkpoint 1");

  var vFolder; // versionFolder
  found = false;
  var subfolders = folder.getFolders();
  while(subfolders.hasNext( )){ // check if version exists
    vFolder = subfolders.next();
    if (vFolder.getName().toUpperCase() == version.toUpperCase()){
      found = true;
      break;
    }
  }
  if(!found){ // create version folder if not exist
    vFolder = folder.createFolder(version);
  }

  var doc = DocumentApp.openById(templateID); // get template document
  var docfile = DriveApp.getFileById(templateID);

  var pagesList, newdoc;

  var images = DocsServiceApp.openBySpreadsheetId("1OirCGjopUu81qrvqJnyIhhi-RIzKfdI07yrge1n0EiU") // get images in spreadsheet
  .getSheetByName(sheetName).getImages();

  Logger.log(images);
  // var images = DocsServiceApp.openBySpreadsheetId("1fM3QKvFegzrojaBN6byyMy4UEqpJge-tTipGkgpUEM0")
  // .getSheetByName("RS NAILS")
  // .getImages();

  var nColor, imgBlob, newdocBody, newdocHeader;

  Logger.log(pages);

  if(pages.indexOf('-') > -1){ // page range

    Logger.log("range of pages input");
    pagesList = pages.split('-');

    for(let j = pagesList[0]; j<= pagesList[1]; j++){
       SpreadsheetApp.getActiveSpreadsheet().toast("Generating row " + j);

      let nColor = sheet.getRange(j, colorColumn).getValue();
      newdocfile = docfile.makeCopy();
      newdocfile.setName("CPSR - "+ nColor + " - "+ company + " - " + date + " - " + version.toUpperCase());
      vFolder.addFile(newdocfile);
      newdoc = DocumentApp.openById(newdocfile.getId());
      newdocBody = newdoc.getBody();
      newdocHeader = newdoc.getHeader();

      newdocBody.replaceText('{PRODUCT_NAME}', productName);
      newdocBody.replaceText('{COLOUR_CODE}', nColor);
      newdocBody.replaceText('{VERSION}', version.substring(1));

      newdocHeader.replaceText('{PRODUCT_NAME}', productName);
      newdocHeader.replaceText('{COLOUR_CODE}', nColor);
      newdocHeader.replaceText('{WHEN_GENERATED_DATE}', date);

      Logger.log(j, pagesList[j])
      imgBlob = images[j - 2].image.blob;

      newdocHeader.getTables()[0].getCell(0,2).clear();
      docImg = newdocHeader.getTables()[0].getCell(0,2).insertImage(0, imgBlob);
      docImg.setHeight(65);
      docImg.setWidth(65);

    }

  }
  else if(pages.indexOf(',') > -1){ // multiple pages

    Logger.log("multiple pages");
    pagesList = pages.split(',');

    for(let j = 0; j<pagesList.length; j++){
      //output doc
      SpreadsheetApp.getActiveSpreadsheet().toast("Generating row " + pagesList[j]);

      nColor = sheet.getRange(pagesList[j], colorColumn).getValue();

      newdocfile = docfile.makeCopy();
      newdocfile.setName("CPSR - "+ nColor + " - "+ company + " - " + date + " - " + version.toUpperCase());
      vFolder.addFile(newdocfile);
      newdoc = DocumentApp.openById(newdocfile.getId());
      newdocBody = newdoc.getBody();
      newdocHeader = newdoc.getHeader();

      newdocBody.replaceText('{PRODUCT_NAME}', productName);
      newdocBody.replaceText('{COLOUR_CODE}', nColor);
      newdocBody.replaceText('{VERSION}', version.substring(1));

      newdocHeader.replaceText('{PRODUCT_NAME}', productName);
      newdocHeader.replaceText('{COLOUR_CODE}', nColor);
      newdocHeader.replaceText('{WHEN_GENERATED_DATE}', date);

      imgBlob = images[pagesList[j] - 2].image.blob;

      newdocHeader.getTables()[0].getCell(0,2).clear();
      docImg = newdocHeader.getTables()[0].getCell(0,2).insertImage(0, imgBlob);
      docImg.setHeight(65);
      docImg.setWidth(65);  
    }

  }
  else{ //single page
    Logger.log("One page");
    SpreadsheetApp.getActiveSpreadsheet().toast("Generating row " + pages);

    nColor = sheet.getRange(pages, colorColumn).getValue();

    // output doc
    newdocfile = docfile.makeCopy();
    newdocfile.setName("CPSR - "+ nColor + " - "+ company + " - " + date + " - " + version.toUpperCase());
    vFolder.addFile(newdocfile);
    newdoc = DocumentApp.openById(newdocfile.getId());
    newdocBody = newdoc.getBody();
    newdocHeader = newdoc.getHeader();

    newdocBody.replaceText('{PRODUCT_NAME}', productName);
    newdocBody.replaceText('{COLOUR_CODE}', nColor);
    newdocBody.replaceText('{VERSION}', version.substring(1));

    newdocHeader.replaceText('{PRODUCT_NAME}', productName);
    newdocHeader.replaceText('{COLOUR_CODE}', nColor);
    newdocHeader.replaceText('{WHEN_GENERATED_DATE}', date);

    imgBlob = images[pages - 2].image.blob;

    newdocHeader.getTables()[0].getCell(0,2).clear();
    docImg = newdocHeader.getTables()[0].getCell(0,2).insertImage(0, imgBlob);
    docImg.setHeight(65);
    docImg.setWidth(65);  
    
  }

 SpreadsheetApp.getActiveSpreadsheet().toast("Done.");



  // sample
  // var newdoc, newdocfile;
  // var v2folder;
  // var v2folder = DriveApp.getFolderById("1YoU35fWLNa952emxS2FbiWAqlh-8fLXd");
  // var rsnailSheet = ss.getSheetByName("RS NAILS");

  // var images = DocsServiceApp.openBySpreadsheetId("1fM3QKvFegzrojaBN6byyMy4UEqpJge-tTipGkgpUEM0")
  // .getSheetByName("RS NAILS")
  // .getImages();
  // var docImg;
  // Logger.log(images);

  // var rsColor
  // for (var x = 2; x <= 32; x++){
  //   rsColor = rsnailSheet.getRange(x, 8).getValue();
  //   newdocfile = docfile.makeCopy();
  //   newdocfile.setName("CPSR - "+ rsColor + " -  Julia Nessa - 19/07/2022 - V4");
  //   v2folder.addFile(newdocfile);
  //   var newdocid = newdocfile.getId();
  //   newdoc = DocumentApp.openById(newdocfile.getId());
  //   var newdocBody = newdoc.getBody();
  //   var newdocHeader = newdoc.getHeader();

  //   newdocBody.replaceText('{PRODUCT_NAME}', productName);
  //   newdocBody.replaceText('{COLOUR_CODE}', rsColor);
  //   newdocBody.replaceText('{VERSION}', '2');

  //   newdocHeader.replaceText('{PRODUCT_NAME}', productName);
  //   newdocHeader.replaceText('{COLOUR_CODE}', rsColor);
  //   newdocHeader.replaceText('{WHEN_GENERATED_DATE}', '18/07/2022');

  //   Logger.log(images[x-2]);
  //   imgBlob = images[x-2].image.blob;

  //   Logger.log(newdocHeader.getTables()[0].getCell(0, 2).getText());
  //   newdocHeader.getTables()[0].getCell(0,2).clear();
  //   Logger.log(newdocHeader.getTables()[0].getCell(0, 2).getText());
  //   docImg = newdocHeader.getTables()[0].getCell(0,2).insertImage(0, imgBlob);
  //   docImg.setHeight(65);
  //   docImg.setWidth(65);
  // }

}

function testReplace(){
  var doc = DocumentApp.openById("1EAKmb41xfmt87tbHKUoDlkiWvF-C4PwhwIOgROgD4Qw");
  var docfile = DriveApp.getFileById("1EAKmb41xfmt87tbHKUoDlkiWvF-C4PwhwIOgROgD4Qw");
  var testDoc = docfile.makeCopy("test2");
  // testDoc.setName("test3");
}

function testReplace(){
  var newdoc = DocumentApp.openById("18_YFAi5NRmpRXqU-4HYFm4N0k_pB8OZGWtsZwOVreEA");
  var header = newdoc.getHeader();
  var body = newdoc.getBody();
  body.replaceText("{PRODUCT_NAME}", "replacme");
  
}

function imageTesting(){
  var ss = SpreadsheetApp.openById("1fM3QKvFegzrojaBN6byyMy4UEqpJge-tTipGkgpUEM0");
  var dashboard = ss.getSheetByName("Dashboard");
  var dataSheet = ss.getSheetByName("Data");
  var rsnailSheet = ss.getSheetByName("RS NAILS");
  
  var image = rsnailSheet.getRange(3, 1).getValue();
  var imageBuilder = image.toBuilder();
  Logger.log(image.getAltTextDescription());
  Logger.log(image.getUrl());
  // Logger.log(image.getContentUrl());
  var images = rsnailSheet.getImages();
  Logger.log(images);
  // const blob = images[0].image.blob; 
  // Logger.log(blob);

  var images2 = DocsServiceApp.openBySpreadsheetId("1fM3QKvFegzrojaBN6byyMy4UEqpJge-tTipGkgpUEM0")
  .getSheetByName("RS NAILS")
  .getImages();


  blob = images2[0].image.blob;
  Logger.log(images2[0]);

  var doc = DocumentApp.openById("1lFMBIuaVGhfnTmJvohWGQbyroDLyEWdNx8Tv7bc8xIA");
  // var docimage = doc.getHeader().getTables()[0].getCell(0, 2).clear();
  doc.getHeader().getTables()[0].getCell(0, 2).clear();
  var docimage = doc.getHeader().getTables()[0].getCell(0, 2).insertImage(0, blob);

  docimage.setWidth(65);
  docimage.setHeight(65);

}

function test4(){

  let x = "abc";
  let y = "a";
  if(x.indexOf(y)>-1){
    Logger.log("yes!");
  }

  pages = "1,2,3,10";
  pagesList = pages.split(',');
  Logger.log(pagesList);

  const now = new Date();
  Logger.log(now);

  const day = now.getDay();
  const month = now.getMonth();
  const year = now.getFullYear();
  const utc = now.getUTCDate()
  newdate = day+" " +month+ " " + year;
  Logger.log(newdate);
  Logger.log(utc);

  const date = Utilities.formatDate(new Date(), "GMT+3", "dd/MM/yyyy");

  Logger.log(date);

  z = "v3";
  Logger.log(z.toUpperCase());
  Logger.log(z.substring(1));
  
  var ss = SpreadsheetApp.getActiveSpreadsheet().getActiveSheet();

  y = "J"
  Logger.log(y.charCodeAt(0) - 64)
}

function test5(){
  var ss = SpreadsheetApp.openById("1OirCGjopUu81qrvqJnyIhhi-RIzKfdI07yrge1n0EiU").getSheetByName("RS NAILS");


  var images = DocsServiceApp.openBySpreadsheetId("1OirCGjopUu81qrvqJnyIhhi-RIzKfdI07yrge1n0EiU").getSheetByName("RS NAILS").getImages();
  Logger.log(images);

}
function test6(){
  string = "my-string";
  if (string.indexOf('-') > -1){
    Logger.log("yes");
  }
}

function testSpinner(){
 SpreadsheetApp.getActiveSpreadsheet().toast("Copying...","",-1);
  Utilities.sleep(5000);
 SpreadsheetApp.getActiveSpreadsheet().toast("Done.");
}