function createFunctionWithTimeout(callback, opt_timeout) {
    var called = false;
    function fn() {
        if (!called) {
            called = true;
            callback();
        }
    }
    setTimeout(fn, opt_timeout || 1000);
    return fn;
}

function trackLogin() {
    var form = document.getElementById('login_form');
    form.addEventListener('submit', function (event) {
        event.preventDefault();
        gtag('event', 'login', {
            'event_category': 'auth',
            'event_callback':
                createFunctionWithTimeout(function () {
                    form.submit();
                })
        });
    });
}

function trackRegister() {
    var form = document.getElementById('sign_up_form');
    form.addEventListener('submit', function (event) {
        event.preventDefault();
        gtag('event', 'sign_up', {
            'event_category': 'auth',
            'event_callback':
                createFunctionWithTimeout(function () {
                    form.submit();
                })
        });
    });
}

function trackLogout() {
    var form = document.getElementById('logoutForm');
    form.addEventListener('submit', function (event) {
        sessionStorage.removeItem('accessToken');
        event.preventDefault();
        gtag('event', 'logout', {
            'event_category': 'auth',
            'event_action':'',
            'event_callback':
                createFunctionWithTimeout(function () {
                    form.submit();
                })
        });
    });
}