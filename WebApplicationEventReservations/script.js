const registerBtn = document.getElementById("register");

if (registerBtn) {
  registerBtn.addEventListener("click", function () {
    window.location.href = "ClientRegister.html";
  });
}

const exploreButton = document.querySelector('.explore-button');

if(exploreButton){
  exploreButton.addEventListener("click", function(){
    window.location.href = "JoinEvents.html";
  });
}

const createButton = document.querySelector(".create-button");

if (createButton) {
  createButton.addEventListener("click", function () {
    window.location.href = "CreateEvent.html";
  });
}

const hamburgerIcon = document.querySelector(".hamburger-icon");
const sideMenu = document.querySelector(".side-menu");
const closeButton = document.querySelector(".close-button");

if (hamburgerIcon) {
  hamburgerIcon.addEventListener("click", function () {
    sideMenu.classList.add("open");
  });
}

if (closeButton) {
  closeButton.addEventListener("click", function () {
    sideMenu.classList.remove("open");
  });
}

const joinButtons = document.querySelectorAll(".join-button");
if (joinButtons) {
  joinButtons.forEach((button) => {
    button.addEventListener("click", function () {
      const dataTarget = button.dataset.target;
      window.location.href = dataTarget;
    });
  });
}

const stepCards = document.querySelectorAll(".step-card");
if (stepCards) {
  stepCards.forEach((stepCard) => {
    stepCard.addEventListener("click", function () {
      const dataTarget = stepCard.dataset.target;
      window.location.href = dataTarget;
    });
  });
}

const primaryButton = document.querySelector(".primary-button");
if (primaryButton) {
  primaryButton.addEventListener("click", function () {
    window.location.href = "CreateEvent.html";
  });
}

const ctaButton = document.querySelector(".cta-button");
if (ctaButton) {
  ctaButton.addEventListener("click", function () {
    window.location.href = "CreateEvent.html";
  });
}


async function loadEvents() {
  const response = await fetch("events_api.php");
  const data = await response.json();

  const containerEvents = document.querySelector(".events-container");

  for (const category in data) {
    const events = data[category];
    const eventsCategory = document.createElement("div");
    const eventsCategoryTitle = document.createElement("h2");
    eventsCategoryTitle.textContent = category;
    eventsCategory.appendChild(eventsCategoryTitle);
    eventsCategoryTitle.className = "events-category-title";

    if (events.length) {
      const eventsList = document.createElement("div");
      eventsList.className = "events-list";

      events.forEach((event) => {
        const eventItem = document.createElement("div");
        eventItem.className = "event-item";

        const eventImage = document.createElement("img");
        eventImage.src = event.image_url;
        eventItem.appendChild(eventImage);
        eventImage.className = "event-item-image";

        const eventTitle = document.createElement("h3");
        eventTitle.textContent = event.title;
        eventItem.appendChild(eventTitle);
        eventTitle.className = "event-item-title";

        const location = document.createElement("p");
        location.textContent = "Location: " + event.location;
        eventItem.appendChild(location);
        location.className = "event-item-description";

        const dateAndTime = document.createElement("p");
        dateAndTime.textContent = "Date: " + event.event_date + " | " + " Time: " + event.event_time;
        eventItem.appendChild(dateAndTime);
        dateAndTime.className = "event-item-description";

        const eventSignUpContainer = document.createElement("div");
        eventSignUpContainer.className = "sign-up-event-details";

        const eventSignUpForm = document.createElement("form");
        eventSignUpForm.action = "submit.php";
        eventSignUpForm.method = "post";

        const formTitle = document.createElement("h3");
        formTitle.textContent = "Event Registration";
        eventSignUpForm.appendChild(formTitle);
        formTitle.className = "sign-up-event-details-title";

        const inputName = document.createElement("input");
        inputName.type = "text";
        inputName.name = "name";
        inputName.placeholder = "Name";
        inputName.required = true;
        eventSignUpForm.appendChild(inputName);
        inputName.className = "sign-up-form-details";

        const inputSurname = document.createElement("input");
        inputSurname.type = "text";
        inputSurname.name = "surname";
        inputSurname.placeholder = "Surname";
        inputSurname.required = true;
        eventSignUpForm.appendChild(inputSurname);
        inputSurname.className = "sign-up-form-details";

        const inputEmail = document.createElement("input");
        inputEmail.type = "email";
        inputEmail.name = "email";
        inputEmail.placeholder = "Email";
        inputEmail.required = true;
        eventSignUpForm.appendChild(inputEmail);
        inputEmail.className = "sign-up-form-details";

        const eventID = document.createElement("input");
        eventID.type = "hidden";
        eventID.name = "event_id";
        eventID.value = event.id;
        eventSignUpForm.appendChild(eventID);

        const sumbitButton = document.createElement("button");
        sumbitButton.type = "submit";
        sumbitButton.textContent = "Join";
        eventSignUpForm.appendChild(sumbitButton);
        sumbitButton.className = "sign-up-form-buttons sign-up-form-submit";

        eventSignUpContainer.appendChild(eventSignUpForm);

        const leaveButton = document.createElement("button");
        leaveButton.textContent = "Back";
        eventSignUpContainer.appendChild(leaveButton);
        leaveButton.className = "sign-up-form-buttons";

        eventItem.appendChild(eventSignUpContainer);

        eventsList.appendChild(eventItem);

        eventImage.addEventListener('click', function(){
            eventItem.classList.toggle('sign-up-event-details-active');
        });

        if(leaveButton){
          leaveButton.addEventListener('click', function(){
            eventItem.classList.remove('sign-up-event-details-active');
          });
        }
      });

      eventsCategory.appendChild(eventsList);
    } else {
      const noEvents = document.createElement("p");
      noEvents.textContent = "Nu există evenimente pentru " + category;
      eventsCategory.appendChild(noEvents);
    }

    containerEvents.appendChild(eventsCategory);
  }
}

loadEvents();

const fileInput = document.getElementById('file-input');
const selectImageButton = document.querySelector('.select-image');

if(selectImageButton){
  selectImageButton.addEventListener('click', function(e){
    e.preventDefault();
    fileInput.click();
  });
}
