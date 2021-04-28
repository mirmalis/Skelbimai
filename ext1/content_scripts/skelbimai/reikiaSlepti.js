function data_item_id(li){
  return Number(li.children[1].getAttribute("data-item-id"));
}
function skelb_info(li){
  return {
    "id": data_item_id(li)
  }
}
async function reikiaSlepti(li, userID) {
  const url = `https://localhost:5001/api/Classifications/${userID}/${data_item_id(li)}/action`;
  const response = await fetch(url);
  if(response.ok){
    return await response.json() === 2;
  }
}