
// checkCollapseState();

// function checkCollapseState(){
//   var queryString = window.location.search;
//   console.log("the url is:" + queryString);
//   const urlParams = new URLSearchParams(queryString)
// }

// var allFolders = document.querySelectorAll(".folder");
// allFolders.forEach(element => {
//   // element.addEventListener("click", setUrlParameters(element));
// });

// var folders: { [id: number] : number };

// function setUrlParameters(folder: any){ 
//   var folderLevel = folder.folderId;
//   var folderId = folder.folderLevel;
//   console.log("set started")
//   if(folderId in folders){
//     delete folders[folderId];
//   } else {
//     for(var singleFolder in folders){
//       if(folders[singleFolder] < folderLevel){
//         delete folders[singleFolder];
//         folders[folderId] = folderLevel;
//       } else if(folders[singleFolder] == folderLevel){
//         folders[folderId] = folderLevel
//       }
//     }
//   }
//   var paramters = "arg=1";
//   var refresh = window.location.protocol + "//" + window.location.host + window.location.pathname + '?' + folders; 
//   window.history.pushState({ path: refresh }, '', refresh);
// }