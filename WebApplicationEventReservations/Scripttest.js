document.addEventListener('DOMContentLoaded', () => {
  const grid = document.querySelector('.testimonials-grid');
  const cards = document.querySelectorAll('.testimonial-card');
  const prevBtn = document.querySelector('.carousel-btn.prev');
  const nextBtn = document.querySelector('.carousel-btn.next');
  
  // lățimea unui card + gap-ul
  const gap = 30; 
  const cardWidth = cards[0].offsetWidth + gap;
  
  let position = 0;
  
  nextBtn.addEventListener('click', () => {
    // nu depășim finalul
    const maxScroll = (cardWidth * cards.length) - grid.parentElement.offsetWidth;
    position = Math.min(position + cardWidth, maxScroll);
    grid.style.transform = `translateX(-${position}px)`;
  });
  
  prevBtn.addEventListener('click', () => {
    // nu coborâm sub 0
    position = Math.max(position - cardWidth, 0);
    grid.style.transform = `translateX(-${position}px)`;
  });
});
