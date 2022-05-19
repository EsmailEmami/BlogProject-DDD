function DocumentInit() {
  jQuery('.main-slider').owlCarousel({
    rtl: true,
    loop: true,
    margin: 8,
    nav: true,
    autoplay: true,
    autoplayTimeout: 5000,
    autoplayHoverPause: true,
    responsive: {
      0: {
        items: 1
      },
      600: {
        items: 1
      },
      1000: {
        items: 1
      }
    }
  });
}

function readURL(input, imgId) {

  if (input.files && input.files[0]) {
    let reader = new FileReader();

    reader.onload = function (e) {
      document.getElementById(imgId).setAttribute('src', e.target.result)
    }

    reader.readAsDataURL(input.files[0]);
  }
}

function startLoading(){
  const sniper = document.querySelector('.snippet');
  sniper.style.display = 'block';
}

function stopLoading(){
  const sniper = document.querySelector('.snippet');
  sniper.style.display = 'none';
}
