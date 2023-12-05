var IdCount = 100;




const register = async () => {
    clearErrorMessages();

    if (!validateUsername() || !validateEmail() || !validatePassword()) {
        return;
    }

    var registerButton = document.getElementById("buttonRegister");
    registerButton.classList.add("rotate");

    try {
        var email = document.getElementById("email").value
        var userName = document.getElementById("userName").value
        var password = document.getElementById("password").value
        var firstName = document.getElementById("firstName").value
        var lastName = document.getElementById("lastName").value
        var User = {email, userName, password, firstName, lastName }

        const res = await fetch('api/users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(User)
        });

        const dataPost = await res.json();
        alert(dataPost.userName + " your registration is successful:)")
        window.location.href = "./login.html"
    }


    catch (er) {
        alert(er)
    }
}

function clearErrorMessages() {
    var emailInput = document.getElementById("email");

    var usernameInput = document.getElementById("userName");
    document.getElementById("usernameLabel").textContent = "";
    document.getElementById("emailLabel").textContent = "";
    document.getElementById("passwordLabel").textContent = "";


}




function validateUsername() {
   
    var usernameInput = document.getElementById("userName");
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
    var emailInput = document.getElementById("email");
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


var user;
async function validatePassword() { 



    var res;
    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }

    var passwordInput = document.getElementById("password");
    var passwordLabel = document.getElementById("passwordLabel");
    var password = document.getElementById("password").value;
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

            }
            else {

                text.innerHTML = "";
            }
            document.getElementById("passwordLabel").textContent = "";
            passwordInput.classList.remove("invalid-input");
            return true;
        }
    }
    catch (e) {
        alert(e)
        return false;
    }
   
}


