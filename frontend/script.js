
let url = "http://localhost:5128/api";
//Get all Categories in table
fetch(url + "/Categories")
    .then(res => {
        return res.json();
    })
    .then(data => {
        let tableData = "";
        data.map((values) => {
            tableData += `<tr>
        <th>${values.name}</th>
        <th>${values.limit}</th>
        <th class="actions"><i class="fa-solid fa-pen-to-square" id="cat-edit" style="color: white; cursor: pointer;"></i>
        <i class="fa-solid fa-trash" style="cursor: pointer;"></i></th></tr>`;
        });
        document.getElementById("cat-table").innerHTML = tableData;
    }).catch((err) => {
        console.log(err);
    })

// Get all transactions in table
fetch(url + "/Transactions")
    .then(res => {
        return res.json();
    })
    .then(data => {
        let tableData = "";
        data.map((values) => {
            tableData += `<tr>
        <th>${values.expName}</th>
        <th>${values.expDesc}</th>
        <th>${values.category}</th>
        <th>${values.amount}</th>
        <th>${values.date}</th>
        <th class="actions"><i class="fa-solid fa-pen-to-square" style="color: white; cursor: pointer;"></i>
        <i class="fa-solid fa-trash" style="cursor: pointer;"></i></th></tr>`;
        });
        document.getElementById("exp-table").innerHTML = tableData;
    }).catch((err) => {
        console.log(err);
    })

// Get all limits in table
fetch(url + "/Limits")
    .then(res => {
        return res.json();
    })
    .then(data => {
        let tableData = "";
        data.map((values) => {
            tableData += `<tr>
        <th>${values.id}</th>
        <th>${values.name}</th>
        <th>${values.value}</th>
        <th class="actions"><i class="fa-solid fa-pen-to-square" style="color: white; cursor: pointer;"></i>
        <i class="fa-solid fa-trash" style="cursor: pointer;"></i></th></tr>`;
        });
        document.getElementById("exp-table").innerHTML = tableData;
    }).catch((err) => {
        console.log(err);
    })

//   post method

// function submitForm() {
//     const form = document.getElementById('myForm');
//     const formData = new FormData(form);

//     const apiEndpoint = 'http://localhost:5128/api/Transactions';
//     fetch(apiEndpoint, {
//         method: 'POST',
//         body: formData,
//     }).then(response => response.json()).then(data => { console.log(data); }).catch(error => { console.error('Error:', error); });
// }

function submitForm() {
    var name = document.getElementById('name').value;
    var category = document.getElementById('category').value;
    var amount = document.getElementById('amount').value;
    var description = document.getElementById('description').value;

    const formData = { name, category, amount, description };

    fetch("http://localhost:5128/api/Transactions",
        {
            method: "POST",
            body: JSON.stringify(formData),
            headers: {
                'Contet-Type': 'application/json'
            }
        })
        .then(res => {
            window.location = "dashboard.html"
        })
        .catch((err) => {
            console.log(err);
        })
}