using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Midtrans.Payment.Data.Model;


namespace Midtrans.Payment.Data
{
    public partial class ApplicationDBContext : DbContext
    {
        public virtual DbSet<MstMidtransResponseTransaction> MstMidtransResponseTransaction { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MstMidtransResponseTransaction>(entity =>
            {
                entity.ToTable("MST_MIDTRANS_RESPONSE_TRANSACTION");

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
                    .HasMaxLength(250)
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
                    .HasColumnName("TRANSACTION_TIME");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_TYPE");

                entity.Property(e => e.VaNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VA_NUMBER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
