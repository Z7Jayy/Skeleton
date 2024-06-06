document.getElementById('loginForm').addEventListener('submit', function(event) {
    event.preventDefault();
    fetch('login.php', {
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
    fetch('signup.php', {
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
    fetch('update_profile.php', {
        method: 'POST',
        body: new FormData(this)
    }).then(response => response.text())
      .then(data => {
          alert(data);
      });
});
