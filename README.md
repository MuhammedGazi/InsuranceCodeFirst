<div align="center">

  ![Logo](https://img.shields.io/badge/INSURANCE-CODEFIRST-005571?style=for-the-badge&logo=shield&logoColor=white)

  # 🛡️ InsuranceCodeFirst: Yapay Zeka Destekli Sigortacılık Ekosistemi 🚀

  **Modern, Ölçeklenebilir ve AI Tabanlı Sigorta Yönetim Platformu**

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
  </p>

  [Proje Hakkında](#-proje-hakkında) • [Özellikler](#-özellikler) • [Kurulum](#-kurulum) • [Galeri](#-proje-ekran-görüntüleri)

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
## 📸 Proje Ekran Görüntüleri
<div align="center">

<img width="100%" alt="Dashboard ve Analiz" src="https://github.com/user-attachments/assets/f266f5a2-8226-428c-ae0d-0c74bb4cb63b" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/275b62f6-013c-4e61-811c-ae251c343fcc" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/66d80704-a49c-49fb-b4be-6e6bf3edcf6c" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/b25ac819-a09f-4e86-81e6-1ecd1362a05c" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/96f550cc-c8a9-4c55-a06a-2efe9e8027a5" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/67b70813-5032-486b-ba1e-91e02032a6bb" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/489a6f26-4d34-4794-863f-2face30d5899" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/a74741cf-0a19-407c-aa00-4bb0b92ddcbe" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/e0450c96-da72-498e-a137-2ac87e37762b" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/950f3ed3-da7d-4c48-b716-4789f3d65e02" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/752aa585-6e2f-4665-8b0a-2e0cd624a9c5" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/0af44aa7-a591-4841-ab2c-432f40c0fb78" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/0bee93e4-9db2-49b2-a5a3-5d247f351edc" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/932f4be9-e360-4cd6-9daa-48987ae89dc2" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/7c293cdc-7814-4447-a61c-82d3767823a2" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/2750840f-55cb-4575-b96e-56ff51b7c516" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/19b0c6b3-0bd5-49a6-b15a-568948ce7df2" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/f1600aec-aeb2-49cf-9ad2-e60063830c88" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/0fb62f8b-105e-489b-adcc-90da8c0d56fe" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/b20f775b-6896-40af-b87b-1f5f5191e7fa" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/7691b194-d829-429e-b14f-eff17b557857" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/4c1405a9-343a-4067-a704-1ba6709719db" />

<img width="100%" alt="Image" src="https://github.com/user-attachments/assets/a00115e0-0b70-4f78-9bba-3f1a1cc111b1" />

</div>
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
