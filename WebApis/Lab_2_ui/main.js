const endpoint = "https://localhost:7159/api/department/";
const tableBody = document.getElementById("tableBody");

async function loadDepartments() {
	try {
		const response = await fetch(endpoint);

		if (!response.ok) {
			throw new Error(`Request failed with status ${response.status}`);
		}

		const departments = await response.json();

		tableBody.innerHTML = departments
			.map(
				(department) => `
					<tr>
						<td>${department.deptId}</td>
						<td>${department.deptName}</td>
						<td>${department.studentsCount}</td>
					</tr>
				`
			)
			.join("");
	} catch (error) {
		tableBody.innerHTML = `
			<tr>
				<td colspan="3">Could not load data. Make sure the API is running and CORS is enabled.</td>
			</tr>
		`;
	}
}

loadDepartments();
