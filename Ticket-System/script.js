document.getElementById('loginForm').addEventListener('submit', function(event) {
    event.preventDefault();
    fetch('/Login/Login', {
        method: 'POST',
        body: new FormData(this)
    }).then(response => response.text())
      .then(data => {
          alert(data);
          if (data === 'Login successful') {
              document.getElementById('profileSection').style.display = 'block';
              $('#loginModal').modal('hide');
          }
      });
});

document.getElementById('signupForm').addEventListener('submit', function(event) {
    event.preventDefault();
    fetch('/Signup/Signup', {
        method: 'POST',
        body: new FormData(this)
    }).then(response => response.text())
      .then(data => {
          alert(data);
          $('#signupModal').modal('hide');
      });
});

document.getElementById('profileForm').addEventListener('submit', function(event) {
    event.preventDefault();
    fetch('/Profile/UpdateProfile', {
        method: 'POST',
        body: new FormData(this)
    }).then(response => response.text())
      .then(data => {
          alert(data);
      });
});

document.getElementById('bookingForm').addEventListener('submit', function(event) {
    event.preventDefault();
    fetch('/BookTicket/BookTicket', {
        method: 'POST',
        body: new FormData(this)
    }).then(response => response.text())
      .then(data => {
          alert(data);
      });
});
