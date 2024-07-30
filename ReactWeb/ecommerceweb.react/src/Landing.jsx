import React from 'react';
import './static/landing.css'; // Yeni CSS yolunu import ettik

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
          <h2>Geniş Ürün Yelpazesi</h2>
          <p>Çeşit çeşit ürünlerle ihtiyacınıza uygun seçenekler sunuyoruz.</p>
        </div>
        <div className="feature">
          <h2>Güvenli Alışveriş</h2>
          <p>Güvenli ödeme yöntemleri ve hızlı kargo seçenekleri.</p>
        </div>
        <div className="feature">
          <h2>24/7 Müşteri Desteği</h2>
          <p>Her zaman destek için buradayız. Sorularınız için bize ulaşabilirsiniz.</p>
        </div>
      </section>
    </div>
  );
}

export default Landing;
