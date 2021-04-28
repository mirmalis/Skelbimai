console.log('background.js');
let userID = "B04E50C7-382C-4CAC-AF32-D24914A11EFA";
chrome.runtime.onInstalled.addListener(() => {
  chrome.storage.sync.set({userID});
});