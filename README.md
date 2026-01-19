$content = @"
#                                                                                    🛡️ InsuranceCodeFirst Project 🚀

<div align="center">

  ![Logo](https://img.shields.io/badge/INSURANCE-CODEFIRST-005571?style=for-the-badge&logo=shield&logoColor=white)
  
  **Yapay Zeka Destekli, N-Katmanlı ve Modern Sigortacılık Ekosistemi**

  <p>
    <a href="#-teknolojiler">
      <img src="https://img.shields.io/badge/.NET%208.0-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET 8.0" />
    </a>
    <a href="#-teknolojiler">
      <img src="https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white" alt="C#" />
    </a>
    <a href="#-yapay-zeka">
      <img src="https://img.shields.io/badge/Hugging%20Face-FFD21E?style=flat-square&logo=huggingface&logoColor=black" alt="Hugging Face" />
    </a>
    <a href="#-yapay-zeka">
      <img src="https://img.shields.io/badge/Gemini%20AI-4285F4?style=flat-square&logo=google&logoColor=white" alt="Gemini AI" />
    </a>
    <a href="#-teknolojiler">
      <img src="https://img.shields.io/badge/ELK%20Stack-005571?style=flat-square&logo=elasticsearch&logoColor=white" alt="ELK Stack" />
    </a>
    <a href="#">
      <img src="https://img.shields.io/badge/Durum-Geliştiriliyor-orange?style=flat-square" alt="Status" />
    </a>
  </p>

  [Proje Hakkında](#-proje-hakkında) • [Özellikler](#-özellikler) • [Kurulum](#-kurulum) • [İletişim](#-iletişim)

</div>

---

## 📖 Proje Hakkında

**InsuranceCodeFirst**, klasik sigortacılık işlemlerini yapay zeka gücüyle modernize eden, **N-Tier (N-Katmanlı)** mimari üzerine kurulu kurumsal bir web çözümüdür.

Sistem; müşteri mesajlarını anlamlandırmak için **Hugging Face**, derinlemesine web araştırması için **Tavily AI**, ve akıllı müşteri iletişimi için **Google Gemini** modellerini entegre eder. Tüm operasyonel süreçler **Elasticsearch** ve **Kibana** üzerinden canlı olarak izlenebilir.

---

## ✨ Özellikler

### 🤖 Yapay Zeka Entegrasyonları
* **🧠 Duygu & Talep Analizi (Hugging Face):** Müşterilerden gelen metinler \`xlm-roberta-large-xnli-anli\` modeli ile analiz edilir. Mesajlar; *Şikayet, Teşekkür, Randevu Talebi* gibi kategorilere otomatik ayrılır.
* **🔍 Akıllı Web Araştırması (Tavily AI):** Statik veritabanı yetersiz kaldığında, sistem interneti tarayarak en güncel sigorta mevzuatlarını veya bilgilerini getirir.
* **✉️ AI Destekli Yanıt Sistemi (Gemini & MailKit):** Müşteri taleplerine Gemini tarafından profesyonel yanıtlar hazırlanır ve MailKit (SMTP) altyapısı ile saniyeler içinde gönderilir.

### 🛠 Teknik Derinlik & Mimari
* **Gözlemlenebilirlik (Observability):** **Serilog** altyapısı ile loglar hem **Elasticsearch**'e indekslenir (Kibana görselleştirmesi için) hem de fiziksel \`.txt\` dosyalarında yedeklenir.
* **Global Exception Handling:** Özel middleware katmanı sayesinde tüm hatalar merkezi olarak yakalanır ve sistemin çökmesi engellenir.
* **Clean Architecture:** Generic Repository, Unit of Work ve Service katmanları ile sürdürülebilir kod yapısı.

---

## 🛠 Teknolojiler

| Alan | Teknoloji | Açıklama |
| :--- | :--- | :--- |
| **Backend** | ![.NET](https://img.shields.io/badge/.NET%208.0-512BD4?style=flat-square&logo=dotnet&logoColor=white) | Yüksek performanslı uygulama çatısı |
| **Veri Erişim** | ![EF Core](https://img.shields.io/badge/EF%20Core-512BD4?style=flat-square&logo=dotnet&logoColor=white) | Code First yaklaşımı |
| **AI / NLP** | ![Hugging Face](https://img.shields.io/badge/Hugging%20Face-FFD21E?style=flat-square&logo=huggingface&logoColor=black) | Metin sınıflandırma modeli |
| **Search** | ![Elastic](https://img.shields.io/badge/Elasticsearch-005571?style=flat-square&logo=elasticsearch&logoColor=white) | Loglama ve veri analizi |
| **Research** | ![Tavily](https://img.shields.io/badge/Tavily%20AI-000000?style=flat-square&logo=google&logoColor=white) | Web tabanlı otonom araştırma |

---

## 📂 Proje Yapısı

```bash
InsuranceCodeFirst
├── 📂 Business          # AI Servisleri (HuggingFace, Tavily, Gemini) & İş Kuralları
├── 📂 DAL               # Veri Tabanı (Context, Migrations, Repositories)
├── 📂 Entity            # Veritabanı Modelleri (Concrete)
├── 📂 DTO               # Veri Transfer Nesneleri
└── 📂 WebUI             # MVC Arayüzü, Middleware ve Controller'lar
