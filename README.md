# Responsi Junior Project - Bintang Restu Bawono

## Deskripsi Proyek
Proyek ini merupakan hasil responsi Junior Project dari mata kuliah **Teknik Basis Data** dan **Pemrograman Berbasis Objek**. Proyek ini mencakup implementasi konsep **Object-Oriented Programming (OOP)**, seperti enkapsulasi, inheritance, polimorfisme, dan abstraksi, serta penerapan manajemen database dengan operasi **CRUD** menggunakan PostgreSQL.

## Fitur Utama
1. **Konsep OOP**
   - **Enkapsulasi**: Metode `ExecuteQuery` pada kelas `DatabaseHelper` menggunakan akses modifier `protected` untuk membatasi akses.
   - **Inheritance**: Kelas `ReferensiHelper` dan `KaryawanHelper` mewarisi kelas `DatabaseHelper`, memungkinkan penggunaan kembali metode dan atribut umum.
   - **Polimorfisme**: Implementasi overriding pada fungsi `Insert Karyawan` dengan nilai default pada kolom tertentu.
   - **Abstraksi**: Penggunaan interface dan pembagian kelas menjadi `DatabaseHelper`, `ReferensiHelper`, dan `KaryawanHelper`.

2. **Manajemen Database**
   - **CRUD pada Tabel Karyawan**:
     - Create: Menambahkan data karyawan baru.
     - Read: Membaca data karyawan dengan join tabel jabatan dan departemen.
     - Update: Memperbarui data karyawan.
     - Delete: Menghapus data karyawan.
   - **GET pada Tabel Jabatan dan Departemen**: Digunakan untuk menyediakan data referensi pada combobox.

3. **Database PostgreSQL**
   - Fungsi PostgreSQL untuk pengelolaan data:
     - `get_karyawan()`: Mengambil data karyawan lengkap dengan detail jabatan dan departemen.
     - `get_jabatan()`: Mengambil data jabatan.
     - `get_departemen()`: Mengambil data departemen.
     - `insert_karyawan()`: Menambahkan data karyawan baru.
     - `edit_karyawan()`: Memperbarui data karyawan.
     - `delete_karyawan()`: Menghapus data karyawan.

4. **Tampilan**
   - Implementasi dalam aplikasi desktop menggunakan **DataGridView** untuk menampilkan data hasil join dari tabel.

## Struktur Proyek
- **DatabaseHelper**: Kelas dasar untuk mengelola koneksi dan query ke database.
- **ReferensiHelper**: Kelas turunan untuk mengelola data referensi (jabatan dan departemen).
- **KaryawanHelper**: Kelas turunan untuk mengelola data karyawan.
- **PostgreSQL Functions**: Fungsi untuk operasi CRUD dan pengambilan data referensi.

## Screenshot
- Tampilan Aplikasi
- ![image](https://github.com/user-attachments/assets/5c6c1d9c-aa14-44f0-bd8e-9fdc44366407)
- ERD Database
- ![image](https://github.com/user-attachments/assets/1b346f3f-9935-48c0-8175-aba230c1c375)


## Kontributor
- **Nama**: Bintang Restu Bawono
- **NIM**: 21/474703/TK/52376

---
