import React from 'react';
import './static/landing.css';
import 'primeicons/primeicons.css';

function Landing() {
  const handleButtonClick = () => {
    // Kullanıcıyı yönlendirme
    window.location.href = '/products'; // Örneğin, ürünler sayfasına yönlendirme
  };

  return (
    <div className="landing-container">
      <header className="landing-header">
        <h1>Hoşgeldiniz!</h1>
        <p>En iyi alışveriş deneyimini yaşamak için doğru yerdesiniz.</p>
        <button className="cta-button" onClick={handleButtonClick}>Ürünlerimizi Görüntüle</button>
      </header>
      <section className="landing-content">
        <div className="feature">
        <i className='pi pi-list-check'></i>
          <p>Çeşit çeşit ürünlerle ihtiyacınıza uygun seçenekler sunuyoruz.</p>
        </div>
        <div className="feature">
          <i className='pi pi-align-right'></i>
          <i className='pi pi-truck'></i>
          <p>Güvenli ödeme yöntemleri ve hızlı kargo seçenekleri.</p>
        </div>
        <div className="feature">
        <i className='pi pi-info-circle'></i>
          <p>Her zaman destek için buradayız. Sorularınız için bize ulaşabilirsiniz.</p>
        </div>
      </section>
    </div>
  );
}

export default Landing;
