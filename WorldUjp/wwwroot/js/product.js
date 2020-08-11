$(function () {
    $.get("/api/ddv")
        .then(function (data) {
            let select = document.getElementById("Product_DDVId");
            for (let i = 0; i < data.length; i++) {
                let option = document.createElement("option");
                option.value = data[i].id;
                option.textContent = data[i].tax + '%';
                select.appendChild(option);
            }
        });
});