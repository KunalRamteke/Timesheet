$(document).ready(function () {
        console.log("ready!");
        $(".newform").validate({
        rules: {
            FirstName: {
                required: true,
                minlength: 4
            },
            LastName: {
                required: true,
                minlength: 5
            },
            Email: {
                required: true,
                minlength: 5
            },
            Password: {
                required: true,
                minlength: 5
            },
            Password_confirmation: {
                required: true,
                minlength: 5,
                equalTo: "#Password"
            },
            messages: {
                Password: {
                    required: "What is your password?",
                    minlength: "Your password must contain more than 5 characters"
                },
                Password_confirmation: {
                    required: "You must confirm your password",
                    minlength: "Your password must contain more than 5 characters",
                    passwordMatch: "Your Passwords Must Match" // custom message for mismatched passwords
                }
            }
        }
    });
});