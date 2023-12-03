
const getAllProducts = async (categories, minPrice, maxPrice, description) => {
    if (sessionStorage.getItem("cart")) {
        cart = JSON.parse(sessionStorage.getItem("cart"))
    }
    try {
        var url =`/api/Products`;
        if (description || minPrice || maxPrice || categories)
            url += `?`
        if (description) url += `desc=${description}`;
        if (minPrice) url += `&minPrice=${minPrice}`;
        if (maxPrice) url += `&maxPrice=${maxPrice}`;
        if (categories) {
            for (let i = 0; i < categories.length; i++) {
                url += `&categoryIds=${categories[i]}`
            }
        }


        if (url == `/api/Products`) {
            url += `?position=1&skip=8`;
        }
        else {
            url += `&position=1&skip=8`;


        }

        console.log(url)
        const res = await fetch(url)

        if (!res.ok)
            window.alert("NotFound")
        else {


            const products = await res.json();
            showProducts( products);

        }
    }
    catch (ex) {
        console.log(ex);
    }

}



const getAllCartegories = async () => {

    count = sessionStorage.getItem("count");
    document.getElementById("ItemsCountText").innerHTML = count;

    try {
        const res = await fetch("api/Categorys")
        const Categories = await res.json();
        return Categories;
    }
    catch (ex) {
        console.log(ex);
    }
}



const showCategories = async () => {
    const Categories = await getAllCartegories();
    console.log(Categories);
    for (let i = 0; i < Categories.length; i++) {
        var tmpCatg = document.getElementById("temp-category");
        var cln = tmpCatg.content.cloneNode(true);
        cln.querySelector("label").for = Categories[i].categoryName;
        cln.querySelector("input").value = Categories[i].categoryName;
        cln.querySelector("input").id = Categories[i].categoryId;
        cln.querySelector("img").src ="./categoryImg/" + Categories[i].img;
        cln.querySelector("span.OptionName").innerText = Categories[i].categoryName;
        document.getElementById("categoryList").appendChild(cln);
    }
}




const showProducts = async (products) => {
     for (let i = 0; i < products.length; i++) {
        var tmp = document.getElementById("temp-card");
        var cln = tmp.content.cloneNode(true);
        cln.querySelector("img").src = "./carsImg/" + products[i].img;
        cln.querySelector("h1").innerText = products[i].productName; 
        cln.querySelector(".price").innerText = products[i].price + 'ש"ח';
        cln.querySelector(".description").innerText = products[i].productDescription;
         cln.querySelector("button").addEventListener("click", () => { addToCart(products[i]) })
         cln.querySelector("category").value = Categories[i].categoryName;

        document.getElementById("PoductList").appendChild(cln);
    }
}



const filterProducts = async () => {
    var categories = [];
    const options = document.querySelectorAll(".opt")
    for (let i = 0; i < options.length; i++) {
        if (options[i].checked) {
            categories.push(options[i].id)
        }
    }
    let minPrice = document.getElementById("minPrice").value;
    let maxPrice = document.getElementById("maxPrice").value;
    let description = document.getElementById("nameSearch").value;
    document.getElementById("PoductList").replaceChildren([]);
    getAllProducts(categories, minPrice, maxPrice, description);

}




var count;
var cart = [];



const addToCart = async (p) => {

    count++;
    document.getElementById("ItemsCountText").innerHTML = count;
    cart.push(p)
    sessionStorage.setItem("cart", JSON.stringify(cart));
    sessionStorage.setItem("count", JSON.stringify(count));
}




