const login = async () => {
    try {
        var userNameLogin = document.getElementById("userNameLogin").value
        var passwordLogin = document.getElementById("passwordLogin").value
        var url = 'api/users' + "?" + "userName=" + userNameLogin + "&password=" + passwordLogin;
        const res = await fetch(url,);
        console.log(res)
        if (!res.ok) {
            throw new Error("eror!!!")
        }
        else {
            var data = await res.json()
            sessionStorage.setItem("user", JSON.stringify(data))
            alert("you loged in")
            window.location.href = "./Products.html"

        }
    }

    catch (er) {
        window.location.href = "./home.html"
      
    }
}


const goToRegister = async () => {
    window.location.href = "./home.html"
}

const goToStore = async () => {
    window.location.href = "./Products.html"
}

