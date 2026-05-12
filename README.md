🚀 Hardware Quest AR

Hardware Quest AR adalah aplikasi Augmented Reality (AR) interaktif edukasional yang dirancang untuk mensimulasikan dan memvisualisasikan komponen perangkat keras (hardware) komputer di dunia nyata. Aplikasi ini memungkinkan pengguna untuk belajar struktur, varian, dan letak komponen PC tanpa harus membongkar unit komputer fisik.

Dikembangkan sebagai proyek Tugas Akhir / Skripsi di Program Studi Teknik Komputer, Universitas Syiah Kuala.

✨ Fitur Utama

📐 Markerless AR Deployment: Deteksi permukaan (Ground Plane Tracking) yang memungkinkan objek 3D seperti Motherboard atau Hard Disk diletakkan dengan ukuran skala asli (1:1) di atas meja pengguna.

🔍 Interactive Data Hotspots: Titik anotasi (titik biru) 3D yang dapat di-tap untuk menampilkan panel informasi mendetail terkait sub-komponen (seperti Soket CPU, Slot RAM, dll).

🛠️ Inspect & Dismantle (Mode Bongkar): Pengguna dapat melihat "jeroan" dari perangkat keras tertutup (misalnya melihat piringan magnetik HDD atau chip silikon di balik pelat pendingin RAM).

🔄 Variant Switcher: Fitur untuk membandingkan wujud dan ukuran antar tipe komponen secara real-time (Contoh: Motherboard ATX vs Mini-ITX, SSD M.2 NVMe vs SATA 2.5").

📝 Evaluation Quiz: Modul ujian pilihan ganda berbasis batas waktu (time-limited) untuk menguji tingkat pemahaman pengguna, dilengkapi dengan sistem penghargaan berupa Experience Points (XP).

💻 Teknologi & Persyaratan Sistem

Proyek ini dibangun menggunakan:

Game Engine: Unity 3D (Versi 6000.0.41f1 atau lebih baru)

AR Framework: Vuforia Engine AR / AR Foundation

Bahasa Pemrograman: C# (.NET)

Target Platform: iOS (iPhone/iPad) & Android

📥 Panduan Instalasi & Build

1. Clone Repository

Pastikan Git sudah terinstal di komputer Anda. Buka terminal dan jalankan perintah berikut:

git clone [https://github.com/rifqiimt/HARDWARE-AR.git](https://github.com/rifqiimt/HARDWARE-AR.git)


2. Membuka di Unity

Buka Unity Hub.

Klik tombol Add dan pilih folder repositori yang baru saja di-clone.

Buka proyek tersebut (Pastikan Anda menggunakan versi Unity Editor yang sesuai).

Catatan: Karena proyek ini tidak menyertakan file tembolok raksasa (telah diabaikan melalui .gitignore), proses impor awal di Unity mungkin memakan waktu beberapa menit.

3. Build ke iOS (Menggunakan Xcode)

Di Unity, buka menu File > Build Settings.

Pilih platform iOS dan klik Switch Platform.

Klik Build dan pilih folder tujuan (biasanya dinamai app atau Build).

Buka file .xcodeproj atau .xcworkspace yang dihasilkan menggunakan aplikasi Xcode di Mac.

Di tab Signing & Capabilities pada Xcode, pastikan Anda telah memilih akun Apple ID (Development Team) Anda.

Hubungkan iPhone/iPad Anda dan tekan tombol Play (▶️) di Xcode untuk mengkompilasi dan menginstal aplikasi ke perangkat keras.

📁 Struktur Direktori Penting

Assets/Scenes/: Berisi scene utama dari aplikasi (seperti Menu Utama, Scene Modul, dan Scene AR).

Assets/Scripts/: Berisi seluruh skrip logika C# pengendali aplikasi:

ARHotspot.cs: Logika deteksi sentuhan (Raycast) dan penampakan panel info.

ModelSwitcher.cs: Logika transisi antar varian komponen 3D.

SlidingPanel.cs: Logika animasi mulus (lerp) untuk memunculkan panel antarmuka UI.

DebugSpawner.cs: Alat (tool) khusus developer untuk memunculkan AR secara paksa saat pengetesan langsung di dalam Unity Editor.

Assets/textures/: Tempat material dan tekstur (gambar pelapis) untuk memperindah model 3D komponen.

👨‍💻 Pengembang

Rifqi Mubarak

Peran: System Architect & Sole Developer

Afiliasi: Teknik Komputer, Universitas Syiah Kuala

Hak Cipta © 2026. Seluruh Hak Dilindungi. Proyek ini ditujukan khusus untuk tujuan akademis.
