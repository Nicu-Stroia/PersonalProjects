const registerBtn = document.getElementById('register');

if(registerBtn){
    registerBtn.addEventListener('click', function(){
        window.location.href = "Client_register.html";
    });
}

const hamburgerIcon = document.querySelector('.hamburger-icon');
const sideMenu = document.querySelector('.side-menu');
const closeButton = document.querySelector('.close-button');

if(hamburgerIcon){
    hamburgerIcon.addEventListener('click', function(){
        sideMenu.classList.add('open');
    })
}

if(closeButton){
    closeButton.addEventListener('click', function() {
        sideMenu.classList.remove('open');
    });
}

const joinButtons = document.querySelectorAll('.join-button');
if(joinButtons){
    joinButtons.forEach(button => {
        button.addEventListener('click', function(){
            const dataTarget=button.dataset.target;
            window.location.href = dataTarget;
        });
    });
}

const stepCards=document.querySelectorAll('.step-card');
if(stepCards){
    stepCards.forEach(stepCard =>{
        stepCard.addEventListener('click', function(){
            const dataTarget=stepCard.dataset.target;
            window.location.href=dataTarget;
        });
    });
}

