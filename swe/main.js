// 1 Meaningful Variable and Function Names
// 2 Keep Functions and Methods Short
// 3 Comments and Documentation
// 4 Consistent Formatting and Indentation
// 5 DRY Principle (Don’t Repeat Yourself)
// 6 Use Meaningful Whitespace
// 7 Proper Error Handling
// 8 Testing
// 9 Refactoring
// 10 Version Control


// 1. Validation Helper Functions (Single Responsibility & Meaningful Names)
const isNotEmpty = (value) => {
    return value.trim() !== "";
};

const isValidEmail = (email) => {
    // Regular expression for basic email validation
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
};

const isPasswordStrong = (password) => {
    return password.length >= 8;
};

const isUsernameValid = (username) => {
    return username.length >= 3;
};

const doPasswordsMatch = (password, confirmPassword) => {
    return password === confirmPassword;
};

// 2. Main Form Validation Logic
const validateRegistrationForm = (formData) => {
    const errors = {}; // Object to collect all errors

    // Fail Fast / Early Returns logic within the checks
    if (!isNotEmpty(formData.fullName)) {
        errors.fullName = "Full name is required.";
    }

    if (!isNotEmpty(formData.email) || !isValidEmail(formData.email)) {
        errors.email = "Please enter a valid email address.";
    }

    if (!isNotEmpty(formData.username) || !isUsernameValid(formData.username)) {
        errors.username = `Username must be at least 3 characters long.`;
    }

    if (!isNotEmpty(formData.password) || !isPasswordStrong(formData.password)) {
        errors.password = `Password must be at least 8 characters.`;
    }

    if (!doPasswordsMatch(formData.password, formData.confirmPassword)) {
        errors.confirmPassword = "Passwords do not match.";
    }

    return {
        isValid: Object.keys(errors).length === 0,
        errors: errors
    };
};

// 3. Event Listener (Separation of Concerns)
document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("customRegisterForm");

    if (form) {
        form.addEventListener("submit", (event) => {
            event.preventDefault();

            // Gather data
            const formData = {
                fullName: form.fullName.value,
                email: form.email.value,
                username: form.username.value,
                password: form.password.value,
                confirmPassword: form.confirmPassword.value
            };

            // Validate
            const validationResult = validateRegistrationForm(formData);

            if (validationResult.isValid) {
                console.log("Form is valid", formData);
            } else {
                console.log(validationResult.errors);
            }
        });
    }
});