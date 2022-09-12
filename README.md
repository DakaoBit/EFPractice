# EFPractice (使用 EntityFrameworkCore 的簡易範例)

## 前置作業
### Step1. 安裝套件
1. Microsoft.EntityFrameworkCore
2. Microsoft.EntityFrameworkCore.Relational
3. Microsoft.EntityFrameworkCore.SqlServer
4. Microsoft.EntityFrameworkCore.Tools

### Step2. 設定資料庫連線字串
### Step3. 設定ApplicationDbContext
### Step4. 設定Program.cs-加入AddDbContext

## 指令
1. Add-Migration "此次移轉名稱" > 產生Migration
2. Update-Database > 將產生的Migration 更新到設定的DB
