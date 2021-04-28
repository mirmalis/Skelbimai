function Asd(postID){
  return fetch('https://localhost:5001/api/', {
    method: 'POST', // or 'PUT'
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      "ttid": channelID(),
      "handle": document.querySelector(".share-title-container h2").innerText,
      "name": document.querySelector(".share-title-container h1").innerText
    }),
  })
  .then(response => response.json())
  .then(data => data)// console.log('Success:', data);
  .catch((error) => {});
}