window.onload = load
let makesList = document.querySelector(".carMakes");
let modelList = document.querySelector(".carModels");

makesList.addEventListener("change", load);

async function load() {
    if (makesList.value != "") {

        modelList.innerHTML = "";

    }

    let request = await fetch(`/Car/GetCarModels?carMakeId=${makesList.value}`);
    let response = await request.json();

    response.forEach(model => {
        let option = document.createElement("option");
        option.value = model.carModelId;
        option.textContent = model.carModelText;
        modelList.appendChild(option)
    });


}
