
async function dodo() {
  chrome.storage.sync.get(['userID'], requestedData => {
    Array.from(
      document.querySelectorAll("li.simpleAds,li.boldAds")
    ).forEach(li => {
      reikiaSlepti(li, requestedData.userID)
        .then(reikia_slepti_result => {
          if (reikia_slepti_result) {
            console.log("removing");
            li.remove();
          } else {
            OnTrue(li, requestedData.userID);
          }
        });
    }
    )
  });
  async function OnTrue(li, userID) {
    let button = document.createElement("button");
    button.innerHTML = "hide always";
    button.onclick = async () => {
      let data = {
        "who": { "id": userID },
        "what": skelb_info(li),
        "action": 2
      };
      const response = await fetch("https://localhost:5001/api/Classifications", {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        // mode: 'cors', // no-cors, *cors, same-origin
        // cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        // credentials: 'same-origin', // include, *same-origin, omit
        headers: {
          'Content-Type': 'application/json'
          // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        // redirect: 'follow', // manual, *follow, error
        // referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
        body: JSON.stringify(data) // body data type must match "Content-Type" header
      });
      if (response.ok) {
        li.remove();
      }
    };
    li.querySelector(".itemInfo").appendChild(button);
  }
}

dodo();
