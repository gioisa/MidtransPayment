using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Midtrans.Payment.Data.Model;


namespace Midtrans.Payment.Data
{
    public partial class ApplicationDBContext : DbContext
    {
        public virtual DbSet<MstGuest> MstGuest { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<RefSubscription> RefSubscription { get; set; }
        public virtual DbSet<RefSubscriptionPack> RefSubscriptionPack { get; set; }
        public virtual DbSet<Repository> Repository { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<TrsMidtransResponseTransaction> TrsMidtransResponseTransaction { get; set; }
        public virtual DbSet<TrsSubscription> TrsSubscription { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MstGuest>(entity =>
            {
                entity.ToTable("MST_GUEST");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("NOTIFICATION");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.IsOpen).HasColumnName("IS_OPEN");

                entity.Property(e => e.Navigation)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NAVIGATION");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");

                entity.Property(e => e.UserFullname)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("USER_FULLNAME");

                entity.Property(e => e.UserMail)
                    .HasMaxLength(150)
                    .HasColumnName("USER_MAIL");

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(50)
                    .HasColumnName("USER_PHONE");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("NOTIFICATION_FK");
            });

            modelBuilder.Entity<RefSubscription>(entity =>
            {
                entity.ToTable("REF_SUBSCRIPTION");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NameSubscription)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NAME_SUBSCRIPTION");

                entity.Property(e => e.Pricing)
                    .HasColumnType("decimal(38, 0)")
                    .HasColumnName("PRICING");

                entity.Property(e => e.TypeSubscription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TYPE_SUBSCRIPTION");

                entity.Property(e => e.UpdateBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY")
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("date")
                    .HasColumnName("UPDATE_DATE")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<RefSubscriptionPack>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("REF_SUBSCRIPTION_PACK");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DurationHour).HasColumnName("DURATION_HOUR");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdSubscription).HasColumnName("ID_SUBSCRIPTION");

                entity.Property(e => e.IsAdditionalService).HasColumnName("IS_ADDITIONAL_SERVICE");

                entity.Property(e => e.SubscriptionPackName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SUBSCRIPTION_PACK_NAME");

                entity.Property(e => e.UpdateBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY")
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("date")
                    .HasColumnName("UPDATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdSubscriptionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSubscription)
                    .HasConstraintName("REF_SUBSCRIPTION_PACK_FK");
            });

            modelBuilder.Entity<Repository>(entity =>
            {
                entity.ToTable("REPOSITORY");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EXTENSION");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("FILE_NAME");

                entity.Property(e => e.IsPublic).HasColumnName("IS_PUBLIC");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("MIME_TYPE");

                entity.Property(e => e.Modul)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("MODUL");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<TrsMidtransResponseTransaction>(entity =>
            {
                entity.ToTable("TRS_MIDTRANS_RESPONSE_TRANSACTION");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Acquirer)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ACQUIRER");

                entity.Property(e => e.ApprovalCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("APPROVAL_CODE");

                entity.Property(e => e.Bank)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BANK");

                entity.Property(e => e.BillKey)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BILL_KEY");

                entity.Property(e => e.BillerCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BILLER_CODE");

                entity.Property(e => e.CardType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CARD_TYPE");

                entity.Property(e => e.ChannelResponseCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CHANNEL_RESPONSE_CODE");

                entity.Property(e => e.ChannelResponseMessage)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CHANNEL_RESPONSE_MESSAGE");

                entity.Property(e => e.Currency)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCY");

                entity.Property(e => e.Eci)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ECI");

                entity.Property(e => e.ExpiryTime)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIRY_TIME");

                entity.Property(e => e.FraudStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FRAUD_STATUS");

                entity.Property(e => e.GrossAmount)
                    .HasColumnType("text")
                    .HasColumnName("GROSS_AMOUNT");

                entity.Property(e => e.Issuer)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ISSUER");

                entity.Property(e => e.MaskedCard)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("MASKED_CARD");

                entity.Property(e => e.MerchantId)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("MERCHANT_ID");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.PaidAt)
                    .HasColumnType("datetime")
                    .HasColumnName("PAID_AT");

                entity.Property(e => e.PaymentAmount)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENT_AMOUNT");

                entity.Property(e => e.PaymentCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENT_CODE");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENT_TYPE");

                entity.Property(e => e.SettlementTime)
                    .HasColumnType("datetime")
                    .HasColumnName("SETTLEMENT_TIME");

                entity.Property(e => e.SignatureKey)
                    .HasColumnType("text")
                    .HasColumnName("SIGNATURE_KEY");

                entity.Property(e => e.StatusCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_CODE");

                entity.Property(e => e.StatusMessage)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_MESSAGE");

                entity.Property(e => e.Store)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STORE");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_ID");

                entity.Property(e => e.TransactionStatus)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_STATUS");

                entity.Property(e => e.TransactionTime)
                    .HasColumnType("datetime")
                    .HasColumnName("TRANSACTION_TIME")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_TYPE");

                entity.Property(e => e.VaNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VA_NUMBER");
            });

            modelBuilder.Entity<TrsSubscription>(entity =>
            {
                entity.ToTable("TRS_SUBSCRIPTION");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DurationOfUse).HasColumnName("DURATION_OF_USE");

                entity.Property(e => e.IdGuest).HasColumnName("ID_GUEST");

                entity.Property(e => e.IdSubscription).HasColumnName("ID_SUBSCRIPTION");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENT_METHOD");

                entity.Property(e => e.PaymentStatus)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENT_STATUS");

                entity.Property(e => e.ScheduledDate)
                    .HasColumnType("date")
                    .HasColumnName("SCHEDULED_DATE");

                entity.Property(e => e.ScheduledHours)
                    .HasColumnType("time(0)")
                    .HasColumnName("SCHEDULED_HOURS");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("TRANSACTION_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdGuestNavigation)
                    .WithMany(p => p.TrsSubscription)
                    .HasForeignKey(d => d.IdGuest)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("TRS_SUBSCRIPTION_FK_1");

                entity.HasOne(d => d.IdSubscriptionNavigation)
                    .WithMany(p => p.TrsSubscription)
                    .HasForeignKey(d => d.IdSubscription)
                    .HasConstraintName("TRS_SUBSCRIPTION_FK_2");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TrsSubscription)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("TRS_SUBSCRIPTION_FK");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessFailedCount).HasColumnName("ACCESS_FAILED_COUNT");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fullname)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.IsLockout).HasColumnName("IS_LOCKOUT");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("MAIL");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.Token)
                    .HasMaxLength(250)
                    .HasColumnName("TOKEN");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("USER_ROLE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdRole)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID_ROLE");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK_USER_ROLE_ROLE");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_USER_ROLE_USER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
