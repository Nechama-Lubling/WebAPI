function showMassage() {

   
    order = JSON.parse(sessionStorage.getItem("order"))
    orderInformation.innerHTML = `הזמנתך מספר:${order.orderId} התקבלה בהצלחה  `


}



function goToStore () {
    window.location.href = "./Products.html"
}

