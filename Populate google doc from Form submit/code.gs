function onOpen(){
    FormApp.getUi().createAddonMenu().addItem('Open','show_sidebar').addToUi();

}

function show_sidebar() {
    const html = HtmlService.createTemplateFromFile("google_forms").evaluate().setTitle("Set data add-on");
  
    FormApp.getUi().showSidebar(html); 

}

function test_table(){
  var doc = DocumentApp.openById("1BL4ts5CWv4dh3ENkw_CTICshCEpKOhvhC6eMJscYMYA");
  var body = doc.getBody();
  var tables = body.getTables();
  var table = tables[0];
  Logger.log(table.getCell(1,1).getText())
  table.getCell(1,1).setText("YES!");
}

// function set_data2(name){
//   var sh = SpreadsheetApp.openById("1QCrCbocJPnQgXx9RY8EZf2YBamViwFh8tkGXx4yYnuw");
//   var data = sh.getSheetByName("Form Responses 1");
//   var lastRow = data.getLastRow();

//   for (var i = 1; i< lastRow; i++){
//     if data.getRange()
//   }

// }
function set_data(name){

  // name = "Ronald Green";
  
  var cellName;
  var notfound = false;
  ss = SpreadsheetApp.openById("1QCrCbocJPnQgXx9RY8EZf2YBamViwFh8tkGXx4yYnuw");
  responses = ss.getSheetByName("Form Responses 1");

  var lrow = responses.getLastRow();
  var i;

  for (var i = 2; i <= lrow; i++){
    cellName = responses.getRange(i, 3).getValue();

    if(cellName.indexOf(name)>-1){
      break;
     }
    else if(i==lrow){
      notfound = true;
    }
  }
  
  if(notfound){
    // not found
  }
  var street = responses.getRange(i, 4).getValue();
  var city = responses.getRange(i, 6).getValue();
  var state = responses.getRange(i, 7).getValue();
  var zipcode = responses.getRange(i, 8).getValue();
  var phonenum = responses.getRange(i, 10).getValue();
  var email = responses.getRange(i, 2).getValue();
  var licensenum = responses.getRange(i, 11).getValue();
  var licensestate = responses.getRange(i, 13).getValue();
  var licenseimageurl = responses.getRange(i, 21).getValue();
  licenseimageurl = getIdFromUrl(licenseimageurl)[0];
  var doc  = DocumentApp.openById("1NVZqvwJZvPzcY_ytkgiOxnCdf3v3W1PqZfZE6QHmeOQ");
  body = doc.getBody();
  var tables = body.getTables();
  var table = tables[0];

  Logger.log("setting " + table.getCell(0,0).getText() + " to " + name);
  try{
    table.getCell(0,0).setText(name);
    table.getCell(0,0).setFontSize(14);
  }
  catch {
    table.getCell(0,0).setText("error with name");
  }
  Logger.log("setting " + table.getCell(1,0).getText() + " to " + street);
  try{
    table.getCell(1,0).setText(street);
  }
  catch{
    table.getCell(1,0).setText("error with street");
  }
  Logger.log("setting " + table.getCell(2,0).getText() + " to " + zipcode);
  try{
    table.getCell(2,0).setText(city + " " + state + " " + zipcode);
  }
  catch{
    table.getCell(2,0).setText("error with city, state, zip")
  }
  try{
    table.getCell(4,0).setText(phonenum + " " + email);
  }
  catch{
    table.getCell(4,0).setText("error with phone number or mail")
  }
  try{
    table.getCell(3,0).setText(licensenum + ", " + licensestate);
  }
  catch{
    table.getCell(3,0).setText("error with licence number and state");
  }

  imgTable = tables[2];
  imgTable.getCell(0,0).clear();
  try{
    var imageBlob = DriveApp.getFileById(licenseimageurl).getBlob();

    var imgDoc = imgTable.getCell(0,0).insertImage(0, imageBlob);
    imgDoc.setWidth("450");
    imgDoc.setHeight("300");
  }
  catch{
    imgTable.getCell(0,0).clear();
    imgTable.getCell(0,0).setText("Image not found");
  }
}

function getIdFromUrl(url) { return url.match(/[-\w]{25,}/); }

function set_data2(name){

  // name = "Nicholas Hampton ";

  var form = FormApp.openById("1LCOR42MzwxRgmmgJ-Bi2fuwfhHNzoNNZtD8H0J0Da_E");
  // responses = app.getResponses(), stringResponses = [];
  // itemResponses = responses.getItemResponses();
  var x, personNum;
  x = 0;
  var firstTime = true;
  var notfound = true;

  var formResponses = form.getResponses();
  for (var i = 0; i < formResponses.length; i++) {
    var formResponse = formResponses[i];
    var itemResponses = formResponse.getItemResponses();
    for (var j = 0; j < itemResponses.length; j++) {
      var itemResponse = itemResponses[j];
      Logger.log('Response #%s to the question "%s" was "%s"',
          (i + 1).toString(),
          itemResponse.getItem().getTitle(),
          itemResponse.getResponse());
      if(itemResponse.getItem().getTitle() == "Full Name (First and Last)"){
        if (itemResponse.getResponse().indexOf(name) > -1) {
          personNum = i;
          notfound = false;
          break;
        }
        break;
      }

    }
    if(!notfound){
      break;
    }
  }

  if (notfound){
    throw new Error( "Error: Name not found in responses" );
    return;
  }

  formResponse = formResponses[personNum];
  itemResponses = formResponse.getItemResponses();
  for (var i = 0; i < itemResponses.length; i++) {
    itemResponse = itemResponses[i];
    Logger.log(itemResponse.getResponse())
    switch (itemResponse.getItem().getTitle()){
      case "Full Name (First and Last)":
        var name = itemResponse.getResponse();  // returns a string
        break;
      case "Street Address":
        var street = itemResponse.getResponse();
        break;
      case "City":
        var city = itemResponse.getResponse();
        break;
      case "State":
        var state = itemResponse.getResponse();
        break;
      case "Zip Code ":
        var zipcode = itemResponse.getResponse();
        break;
      case "Phone Number ":
        var phonenum = itemResponse.getResponse();
        break;
      case "Email":
        var email = itemResponse.getResponse();
        break;
      case "Driver License Number":
        var licensenum = itemResponse.getResponse();
        break;
      case "Driver License State":
        var licensestate = itemResponse.getResponse();
        break;

      case "Please Upload your Driver License ":
        var licenseimageurl = itemResponse.getResponse();
        // licenseimageurl = "1q_cJEuc5Q6D8biBRy5BTo8rduwxeIj5H";
        break;
      }
  }

  var doc  = DocumentApp.openById("1NVZqvwJZvPzcY_ytkgiOxnCdf3v3W1PqZfZE6QHmeOQ");
  body = doc.getBody();
  var tables = body.getTables();
  var table = tables[0];

  Logger.log("setting " + table.getCell(0,0).getText() + " to " + name);
  try{
    table.getCell(0,0).setText(name);
    table.getCell(0,0).setFontSize(14);
  }
  catch {
    table.getCell(0,0).setText("error with name");
  }
  Logger.log("setting " + table.getCell(1,0).getText() + " to " + street);
  try{
    table.getCell(1,0).setText(street);
  }
  catch{
    table.getCell(1,0).setText("error with street");
  }
  Logger.log("setting " + table.getCell(2,0).getText() + " to " + zipcode);
  try{
    table.getCell(2,0).setText(city + " " + state + " " + zipcode);
  }
  catch{
    table.getCell(2,0).setText("error with city, state, zip")
  }
  try{
    table.getCell(4,0).setText(phonenum + " " + email);
  }
  catch{
    table.getCell(4,0).setText("error with phone number or mail")
  }
  try{
    table.getCell(3,0).setText(licensenum + ", " + licensestate);
  }
  catch{
    table.getCell(3,0).setText("error with licence number and state");
  }

  var imageBlob = DriveApp.getFileById(licenseimageurl).getBlob();
  // doc.getBody().insertImage(0, imageBlob); 
  // table.getCell(0,2).setText("image goes here");
  imgTable = tables[2];
  imgTable.getCell(0,0).clear();
  var imgDoc = imgTable.getCell(0,0).insertImage(0, imageBlob);
  imgDoc.setWidth("450");
  imgDoc.setHeight("300");


}
// function setTrigger() {
//   ScriptApp.newTrigger("sendText")
//   .forForm("1LCOR42MzwxRgmmgJ-Bi2fuwfhHNzoNNZtD8H0J0Da_E")
//   .onFormSubmit()
//   .create();
// }
// function sendText(e) {

//   var sh = SpreadsheetApp.openById("1QCrCbocJPnQgXx9RY8EZf2YBamViwFh8tkGXx4yYnuw");
//   var settings = sh.getSheetByName("settings");
//   var data = sh.getSheetByName("Form Responses 1");
//   var authkey = settings.getRange(2,1).getValue();
//   var number = "+13125667833";
//   var lastRow = data.getLastRow();
//   var name = data.getRange(lastRow, 3).getValue();

//   var message = name + " has just submitted a form!";

//   const url = "https://rest.clicksend.com/v3/sms/send"
//   const params = {
//     method: "post",
//     headers: {Authorization: authkey},
//     contentType: "application/json",
//     payload: JSON.stringify({
//       "messages":[
//         {
//           "body":message,
//           "source":"googleappsscript",
//           "to":number
//         }
//       ]
//     })
//   }
//   const res = UrlFetchApp.fetch(url, params);
//   UrlFetchApp.fetch(url, params);
//   Logger.log(res.getResponseCode);
//   if (res.getResponseCode == 200 || res.getResponseCode == 201 || res.getResponseCode == 202){
//     Logger.log("Success!")
//   }
//   else {
//     Logger.log("Failure, " + res.getResponseCode.toString())
//   }

// }