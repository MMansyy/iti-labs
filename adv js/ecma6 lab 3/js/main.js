const resultSection = document.querySelector('#resultSection')
const countryInput = document.querySelector('#countryInput')
const countryForm = document.querySelector('#countryForm')

const fetchCountry = async (country) => {
    let res = await fetch(`https://restcountries.com/v2/name/${country}`)
    let countryData = await res.json();
    countryData = countryData[0]
    console.log(countryData);
    if (countryData) {
        let res2 = await fetch(`https://restcountries.com/v2/alpha/${countryData.borders[0]}`)
        let neighborDetails = await res2.json();
        console.log(neighborDetails);
        displayCountry([countryData, neighborDetails])
    }
}

const displayCountry = (data) => {
    let html = '';
    data.forEach(country => {
        html += `
        <div class="col-md-4">
            <h4 class="text-center display-6 mb-3">${country === data[0] ? 'Country' : 'Neighbor Country'}</h4>
            <div class="card m-2 rounded-3 shadow">
                <img src="${country.flags.png}" class="card-img-top img-fluid img" alt="${country.name}">
                <div class="card-body text-center">
                    <h5 class="card-title ">${country.name}</h5>
                    <p class="card-text">${country.region}</p>
                </div>
                <ul class="list-group list-group-flush">
                    <li class="list-group-item"><strong>Population :</strong> ${country.population}</li>
                    <li class="list-group-item"><strong>Language: </strong> ${country.languages[0].name}</li>
                    <li class="list-group-item"><strong>Currency:</strong> ${country.currencies[0].name}</li>
                </ul>
            </div>
        </div>`;
    });
    resultSection.innerHTML = html;
    resultSection.classList.remove('d-none')
};




countryForm.addEventListener('submit', (e) => {
    e.preventDefault()
    let country = countryInput.value.trim()
    fetchCountry(country)
})


