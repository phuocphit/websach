namespace WebSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietHoaDons",
                c => new
                    {
                        MaHoaDon = c.String(nullable: false, maxLength: 50),
                        MaSach = c.String(maxLength: 50, unicode: false),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                        ThanhTien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.HoaDons", t => t.MaHoaDon)
                .ForeignKey("dbo.Sachs", t => t.MaSach)
                .Index(t => t.MaHoaDon)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        MaHoaDon = c.String(nullable: false, maxLength: 50),
                        NgayHoaDon = c.DateTime(nullable: false),
                        TinhTrang = c.String(maxLength: 50),
                        TongGiaTri = c.Int(nullable: false),
                        DiaChi = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.Users", t => t.Email)
                .Index(t => t.Email);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        UserName = c.String(maxLength: 50, unicode: false),
                        PassWord = c.String(maxLength: 50, unicode: false),
                        RoleID = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Email)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 50, unicode: false),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Sachs",
                c => new
                    {
                        MaSach = c.String(nullable: false, maxLength: 50, unicode: false),
                        TenSach = c.String(maxLength: 50),
                        MaLoaiSach = c.String(maxLength: 50, unicode: false),
                        TacGia = c.String(maxLength: 50),
                        MaNXB = c.String(maxLength: 50, unicode: false),
                        GiaBan = c.Int(nullable: false),
                        SoLuongTon = c.Int(nullable: false),
                        SoTrang = c.Int(nullable: false),
                        images = c.String(),
                        NamXuatBan = c.DateTime(nullable: false),
                        NoiDung = c.String(),
                    })
                .PrimaryKey(t => t.MaSach)
                .ForeignKey("dbo.LoaiSachs", t => t.MaLoaiSach)
                .ForeignKey("dbo.NhaXuatBans", t => t.MaNXB)
                .Index(t => t.MaLoaiSach)
                .Index(t => t.MaNXB);
            
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        MaGioHang = c.Int(nullable: false, identity: true),
                        MaSach = c.String(maxLength: 50, unicode: false),
                        TenSach = c.String(maxLength: 50),
                        SoLuongMua = c.Int(nullable: false),
                        GiaBan = c.Int(nullable: false),
                        MaGiaoDIch = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaGioHang)
                .ForeignKey("dbo.Sachs", t => t.MaSach)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.LoaiSachs",
                c => new
                    {
                        MaLoaiSach = c.String(nullable: false, maxLength: 50, unicode: false),
                        TenLoaiSach = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaLoaiSach);
            
            CreateTable(
                "dbo.NhaXuatBans",
                c => new
                    {
                        MaNXB = c.String(nullable: false, maxLength: 50, unicode: false),
                        TenNXB = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaNXB);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sachs", "MaNXB", "dbo.NhaXuatBans");
            DropForeignKey("dbo.Sachs", "MaLoaiSach", "dbo.LoaiSachs");
            DropForeignKey("dbo.GioHangs", "MaSach", "dbo.Sachs");
            DropForeignKey("dbo.ChiTietHoaDons", "MaSach", "dbo.Sachs");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.HoaDons", "Email", "dbo.Users");
            DropForeignKey("dbo.ChiTietHoaDons", "MaHoaDon", "dbo.HoaDons");
            DropIndex("dbo.GioHangs", new[] { "MaSach" });
            DropIndex("dbo.Sachs", new[] { "MaNXB" });
            DropIndex("dbo.Sachs", new[] { "MaLoaiSach" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.HoaDons", new[] { "Email" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaSach" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaHoaDon" });
            DropTable("dbo.NhaXuatBans");
            DropTable("dbo.LoaiSachs");
            DropTable("dbo.GioHangs");
            DropTable("dbo.Sachs");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.HoaDons");
            DropTable("dbo.ChiTietHoaDons");
        }
    }
}
