


//to pass to a diffrent file of js;


let cart = JSON.parse(sessionStorage.getItem("cart"));
let count = JSON.parse(sessionStorage.getItem("count"));
let user = JSON.parse(sessionStorage.getItem("user"));




async function showProductsInCart() {
    let cart = JSON.parse(sessionStorage.getItem("cart"));
    console.log(cart)
    console.log("here")
    for (let i = 0; i < cart.length; i++) {
        var tmp = document.getElementById("temp-row");
        var cln = tmp.content.cloneNode(true);
        cln.querySelector(".image").src = "./carsImg/" + cart[i].img;
        cln.querySelector(".itemName").innerText = cart[i].productName;
        cln.querySelector(".price").innerText = cart[i].price;
        cln.querySelector(".descriptionColumn").innerText = cart[i].productDescription;
        cln.querySelector(".totalColumn").addEventListener("click", () => { deleteProductFromCart(cart[i]) })
        document.getElementById("itemsBody").appendChild(cln);
    }


    var sum = sumCart(cart);
    sessionStorage.setItem("sum", sum);

    document.getElementById("totalAmount").innerHTML = sum;
    document.getElementById("itemCount").innerHTML = cart.length;
}

async function deleteProductFromCart(productInCart) {
    let cart = JSON.parse(sessionStorage.getItem("cart"));
    let cartFilter = cart.filter(c => c.productId !== productInCart.productId);
    let countFilter = JSON.parse(sessionStorage.getItem("count"));
    countFilter -= 1;
    sessionStorage.setItem("count", JSON.stringify(countFilter));
    sessionStorage.setItem("cart", []);
    sessionStorage.setItem("cart", JSON.stringify(cartFilter));
    document.getElementById("itemsBody").replaceChildren([]);
    showProductsInCart();
}

function sumCart(cart) {
    var sum = 0;
    for (let i = 0; i < cart.length; i++) {
        sum += cart[i].price;
    }
    return sum;
}

async function placeOrder() {


    let OrderItems = [];
    for (let i = 0; i < cart.length; i++) {
        let p = cart[i].productId
        let q = 0
        OrderItems[i] = new OrderItem(p, q)
    }
    let mySum = sumCart(cart);
    if (user) {
        var order = {
            orderDate: new Date(),
            orderSum: mySum,
            userId: user.userId,
            orderItems: OrderItems
        }
        try {
            const res = await fetch('api/Orders', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(order)
            });
            if (res.ok) {
                const newOrder = await res.json();
                alert(`order number:  ${newOrder.orderId} created At: ${newOrder.orderDate}`)
                console.log(newOrder)
                sessionStorage.setItem("order", JSON.stringify(newOrder))
                window.location.href = "./PostOrder.html"
            }
            else {
                alert("order not created")
            }
        }
        catch (error) {
            console.log(error)
        }
    }


    else {
        window.location.href = "./home.html"
    }
}



class OrderItem {
    constructor(productId, quantity) {
        this.productId = productId;
        this.quantity = quantity;
    }
}
