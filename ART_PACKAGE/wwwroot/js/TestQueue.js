var login = "sasinst";
var password = "P@ssw0rd";

var basicAuth = btoa(`${login}:${password}`); // Base64 encode the credentials

var res = fetch("https://sas-webt-test/SASComplianceSolutionsMid/rest/queues", {
    headers: new Headers({
        "Authorization": `Basic ${ login }:${ password }}`,
        credentials: 'include',




        mode: 'no-cors'
    }),
  
})
    .then(response => {
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response;
    })
    .then(data => console.log(data))
    .catch(error => console.error('Error:', error));
