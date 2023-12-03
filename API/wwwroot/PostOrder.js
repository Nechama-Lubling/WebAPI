



function showMassage() {

    order=JSON.parse(sessionStorage.getItem("order"))
    document.getElementsByClassName("a").innerText=order.orderId


}