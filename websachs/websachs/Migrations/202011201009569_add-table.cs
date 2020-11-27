namespace websachs.Migrations
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
                        id = c.Int(nullable: false, identity: true),
                        MaHoaDon = c.Int(nullable: false),
                        MaSach = c.String(maxLength: 50, unicode: false),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                        ThanhTien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HoaDons", t => t.MaHoaDon, cascadeDelete: true)
                .ForeignKey("dbo.Sachs", t => t.MaSach)
                .Index(t => t.MaHoaDon)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        MaHoaDon = c.Int(nullable: false, identity: true),
                        NgayHoaDon = c.DateTime(nullable: false),
                        TinhTrang = c.String(maxLength: 50),
                        TongGiaTri = c.Int(nullable: false),
                        DiaChi = c.String(maxLength: 50),
                        UserName = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.Users", t => t.UserName)
                .Index(t => t.UserName);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        PassWord = c.String(nullable: false, maxLength: 50, unicode: false),
                        RoleID = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.UserName)
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
            DropForeignKey("dbo.HoaDons", "UserName", "dbo.Users");
            DropForeignKey("dbo.ChiTietHoaDons", "MaHoaDon", "dbo.HoaDons");
            DropIndex("dbo.GioHangs", new[] { "MaSach" });
            DropIndex("dbo.Sachs", new[] { "MaNXB" });
            DropIndex("dbo.Sachs", new[] { "MaLoaiSach" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.HoaDons", new[] { "UserName" });
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
