const user = sessionStorage.getItem("user")
const jsonUser = JSON.parse(user)

const loadPage = () => {
    if (!user) {
        window.location.href = "./login.html"
    }

    const jsonUser = JSON.parse(user)
    welcome.innerHTML = ` שלום  ${jsonUser.userName}  `
    const userNameUpdate = document.getElementById("userNameUpdate")
    userNameUpdate.value = jsonUser.userName

    const emailUpdate = document.getElementById("emailUpdate")
    emailUpdate.value = jsonUser.email


    const passwordUpdate = document.getElementById("passwordUpdate")
    passwordUpdate.value = jsonUser.password

    const firstNameUpdate = document.getElementById("firstNameUpdate")
    firstNameUpdate.value = jsonUser.firstName

    const lastNameUpdate = document.getElementById("lastNameUpdate")
    lastNameUpdate.value = jsonUser.lastName

}

const update = async () => {

    clearErrorMessages();

    if (!validateUsername() || !validateEmail() || !validatePassword()) {
        return;
    }

    try {
        var userId = jsonUser.userId
        var email = document.getElementById("emailUpdate").value
        var userName = document.getElementById("userNameUpdate").value
        var password = document.getElementById("passwordUpdate").value
        var firstName = document.getElementById("firstNameUpdate").value
        var lastName = document.getElementById("lastNameUpdate").value
        var User = { userId, email, firstName, lastName, password ,userName}
        console.log(User)
        var url = 'api/users' + "/" + userId
        const res = await fetch(url, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(User)

        });
        const dataPost = await res.json();

        alert(dataPost.userName +"עודכן")
        window.location.href = "./Products.html"
    }

catch (er) {
    alert(er.message+ "ERORR")
}

}



function clearErrorMessages() {
    var emailInput = document.getElementById("emailUpdate");
    var usernameInput = document.getElementById("userNameUpdate");
    document.getElementById("usernameLabel").textContent = "";
    document.getElementById("emailLabel").textContent = "";
    document.getElementById("passwordLabel").textContent = "";


}




function validateUsername() {

    var usernameInput = document.getElementById("userNameUpdate");
    var usernameLabel = document.getElementById("usernameLabel");
    var username = usernameInput.value;

    if (username.length >= 30) {
        usernameInput.classList.add("invalid-input");
        usernameLabel.textContent = "שם משתמש ארוך מדי";
        return false;
    } else {
        usernameLabel.textContent = "";
        return true;
    }
}



function validateEmail() {
    var emailInput = document.getElementById("emailUpdate");
    var emailLabel = document.getElementById("emailLabel");
    var email = emailInput.value;

    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (!emailRegex.test(email)) {
        emailInput.classList.add("invalid-input");
        emailLabel.textContent = "כתובת מייל לא חוקית";
        return false;
    } else {
        emailLabel.textContent = "";
        emailInput.classList.remove("invalid-input");
        return true;
    }
}


async function validatePassword() {



    var res;
    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }

    var passwordInput = document.getElementById("passwordUpdate");
    var passwordLabel = document.getElementById("passwordLabel");
    var password = document.getElementById("passwordUpdate").value;
    var meter = document.getElementById('password-strength-meter');
    var text = document.getElementById('password-strength-text');
    try {
        await fetch('api/Users/check',
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(password)

            })
            .then(r => r.json())
            .then(data => res = data)


        if (res <= 2) {

            meter.value = res;
            passwordInput.classList.add("invalid-input");
            passwordLabel.textContent = "הסיסמה שלך חלשה מדי";
            return false;


        }
        else {
            meter.value = res;
            if (password !== "") {
                text.innerHTML = "Strength: " + strength[res];

            } else {

                text.innerHTML = "";
            }
            document.getElementById("passwordLabel").textContent = "";
            passwordInput.classList.remove("invalid-input");
            return true;
        }
    }
    catch (e) {
        alert(e)
    }
}

const goToStore = async () => {
    window.location.href = "./Products.html"
}

