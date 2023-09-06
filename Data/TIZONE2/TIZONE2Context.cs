using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.TIZONE2
{
    public partial class TIZONE2Context : DbContext
    {
        public TIZONE2Context()
        {
        }

        public TIZONE2Context(DbContextOptions<TIZONE2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Master> Masters { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TIZONE2")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Master>(entity =>
            {
                entity.HasKey(e => e.Key97)
                    .HasName("PKMASTER");

                entity.ToTable("MASTER");

                entity.HasIndex(e => e.Nprcustsbb, "X10MASTER");

                entity.HasIndex(e => e.Relmstrkey, "X1MASTER");

                entity.HasIndex(e => e.Canourref, "X2MASTER");

                entity.HasIndex(e => e.Canprnref, "X3MASTER");

                entity.HasIndex(e => e.Cannprnref, "X4MASTER");

                entity.HasIndex(e => e.Ccy, "X5MASTER");

                entity.HasIndex(e => e.Exemplar, "X6MASTER");

                entity.HasIndex(e => new { e.Pricustsbb, e.Pricustmnm }, "X7MASTER");

                entity.HasIndex(e => e.BhalfBrn, "X8MASTER");

                entity.HasIndex(e => e.Workgroup, "X9MASTER");

                entity.Property(e => e.Key97)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("KEY97");

                entity.Property(e => e.AcctBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ACCT_BRN")
                    .IsFixedLength();

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasPrecision(15)
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmtOS)
                    .HasPrecision(15)
                    .HasColumnName("AMT_O_S");

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.Billlevel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("BILLLEVEL")
                    .IsFixedLength();

                entity.Property(e => e.Bookoffdat)
                    .HasColumnType("DATE")
                    .HasColumnName("BOOKOFFDAT");

                entity.Property(e => e.Cannprnref)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("CANNPRNREF")
                    .IsFixedLength();

                entity.Property(e => e.Canourref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CANOURREF")
                    .IsFixedLength();

                entity.Property(e => e.Canprnref)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("CANPRNREF")
                    .IsFixedLength();

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.ChargeFor)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHARGE_FOR")
                    .IsFixedLength();

                entity.Property(e => e.CtrctDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CTRCT_DATE");

                entity.Property(e => e.Datatakeon)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DATATAKEON")
                    .IsFixedLength();

                entity.Property(e => e.DeactDate)
                    .HasColumnType("DATE")
                    .HasColumnName("DEACT_DATE");

                entity.Property(e => e.DfltWkgrp)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("DFLT_WKGRP")
                    .IsFixedLength();

                entity.Property(e => e.Docsprep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOCSPREP")
                    .IsFixedLength();

                entity.Property(e => e.Docspreprq)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOCSPREPRQ")
                    .IsFixedLength();

                entity.Property(e => e.Ebankmsref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EBANKMSREF")
                    .IsFixedLength();

                entity.Property(e => e.EcflnkKey)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("ECFLNK_KEY");

                entity.Property(e => e.EcflnkRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ECFLNK_REF")
                    .IsFixedLength();

                entity.Property(e => e.Eligfordel)
                    .HasColumnType("DATE")
                    .HasColumnName("ELIGFORDEL");

                entity.Property(e => e.EvCount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EV_COUNT");

                entity.Property(e => e.Exemplar)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("EXEMPLAR");

                entity.Property(e => e.ExpiryDat)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DAT");

                entity.Property(e => e.ExpiryLoc)
                    .HasMaxLength(29)
                    .IsUnicode(false)
                    .HasColumnName("EXPIRY_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Extfield)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("EXTFIELD");

                entity.Property(e => e.InputBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("INPUT_BRN")
                    .IsFixedLength();

                entity.Property(e => e.LiabAmt)
                    .HasPrecision(15)
                    .HasColumnName("LIAB_AMT");

                entity.Property(e => e.LiabCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("LIAB_CCY")
                    .IsFixedLength();

                entity.Property(e => e.Locked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LOCKED")
                    .IsFixedLength();

                entity.Property(e => e.Mailtobrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("MAILTOBRN")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.NoBrowse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NO_BROWSE")
                    .IsFixedLength();

                entity.Property(e => e.NpcSwBic)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("NPC_SW_BIC")
                    .IsFixedLength();

                entity.Property(e => e.NpcpPty)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("NPCP_PTY");

                entity.Property(e => e.NprRef)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("NPR_REF")
                    .IsFixedLength();

                entity.Property(e => e.Nprcustmnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NPRCUSTMNM")
                    .IsFixedLength();

                entity.Property(e => e.Nprcustsbb)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("NPRCUSTSBB")
                    .IsFixedLength();

                entity.Property(e => e.NprnameL1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NPRNAME_L1")
                    .IsFixedLength();

                entity.Property(e => e.OrigRef)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("ORIG_REF")
                    .IsFixedLength();

                entity.Property(e => e.Origbranch)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ORIGBRANCH")
                    .IsFixedLength();

                entity.Property(e => e.Origisuser)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ORIGISUSER")
                    .IsFixedLength();

                entity.Property(e => e.Origname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ORIGNAME")
                    .IsFixedLength();

                entity.Property(e => e.Origref1)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("ORIGREF")
                    .IsFixedLength();

                entity.Property(e => e.Origteam)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ORIGTEAM")
                    .IsFixedLength();

                entity.Property(e => e.Origuser)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("ORIGUSER");

                entity.Property(e => e.ParentEv)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("PARENT_EV");

                entity.Property(e => e.Pccenddadj)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PCCENDDADJ")
                    .IsFixedLength();

                entity.Property(e => e.PcpPty)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("PCP_PTY");

                entity.Property(e => e.PcpSwBic)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_BIC")
                    .IsFixedLength();

                entity.Property(e => e.Prdclass)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PRDCLASS")
                    .IsFixedLength();

                entity.Property(e => e.PrevSts)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PREV_STS")
                    .IsFixedLength();

                entity.Property(e => e.PriRef)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("PRI_REF")
                    .IsFixedLength();

                entity.Property(e => e.Pricustmnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRICUSTMNM")
                    .IsFixedLength();

                entity.Property(e => e.Pricustsbb)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("PRICUSTSBB")
                    .IsFixedLength();

                entity.Property(e => e.Primarycus)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("PRIMARYCUS");

                entity.Property(e => e.PrinameL1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PRINAME_L1")
                    .IsFixedLength();

                entity.Property(e => e.Prodtype)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("PRODTYPE");

                entity.Property(e => e.RefLock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REF_LOCK")
                    .IsFixedLength();

                entity.Property(e => e.RefnoBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("REFNO_BRN")
                    .IsFixedLength();

                entity.Property(e => e.RefnoMbe)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("REFNO_MBE")
                    .IsFixedLength();

                entity.Property(e => e.RefnoPfix)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("REFNO_PFIX")
                    .IsFixedLength();

                entity.Property(e => e.RefnoSerl)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REFNO_SERL");

                entity.Property(e => e.ReimbChgs)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REIMB_CHGS")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrkey)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("RELMSTRKEY");

                entity.Property(e => e.Relmstrref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF")
                    .IsFixedLength();

                entity.Property(e => e.RespUser)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("RESP_USER");

                entity.Property(e => e.Sharedliab)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SHAREDLIAB")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Swiftversn)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SWIFTVERSN");

                entity.Property(e => e.TakeAmdno)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TAKE_AMDNO");

                entity.Property(e => e.TakeDate)
                    .HasColumnType("DATE")
                    .HasColumnName("TAKE_DATE");

                entity.Property(e => e.TakePayno)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TAKE_PAYNO");

                entity.Property(e => e.Takeon)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TAKEON")
                    .IsFixedLength();

                entity.Property(e => e.TfrMthd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TFR_MTHD")
                    .IsFixedLength();

                entity.Property(e => e.Totliabamt)
                    .HasPrecision(15)
                    .HasColumnName("TOTLIABAMT");

                entity.Property(e => e.Totliabccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TOTLIABCCY")
                    .IsFixedLength();

                entity.Property(e => e.TransBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("TRANS_BRN")
                    .IsFixedLength();

                entity.Property(e => e.Tstamp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TSTAMP");

                entity.Property(e => e.Typeflag)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TYPEFLAG");

                entity.Property(e => e.Usercode1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("USERCODE1")
                    .IsFixedLength();

                entity.Property(e => e.Usercode2)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("USERCODE2")
                    .IsFixedLength();

                entity.Property(e => e.Usercode3)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("USERCODE3")
                    .IsFixedLength();

                entity.Property(e => e.Useroptn1)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("USEROPTN1");

                entity.Property(e => e.Useroptn2)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("USEROPTN2");

                entity.Property(e => e.Useroptn3)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("USEROPTN3");

                entity.Property(e => e.Useroptn4)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("USEROPTN4");

                entity.Property(e => e.Useroptn5)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("USEROPTN5");

                entity.Property(e => e.UtilisAmt)
                    .HasPrecision(15)
                    .HasColumnName("UTILIS_AMT");

                entity.Property(e => e.UtilisCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("UTILIS_CCY")
                    .IsFixedLength();

                entity.Property(e => e.Verlevel)
                    .HasColumnType("NUMBER")
                    .HasColumnName("VERLEVEL");

                entity.Property(e => e.Workgroup)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("WORKGROUP")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.Key97)
                    .HasName("PKNOTE");

                entity.ToTable("NOTE");

                entity.HasIndex(e => e.MasterKey, "X1NOTEENT");

                entity.Property(e => e.Key97)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("KEY97");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CODE")
                    .IsFixedLength();

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.Createdate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEDATE");

                entity.Property(e => e.Createtime)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CREATETIME")
                    .IsFixedLength();

                entity.Property(e => e.Emphasis)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMPHASIS")
                    .IsFixedLength();

                entity.Property(e => e.MasterKey)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("MASTER_KEY");

                entity.Property(e => e.NoteEvent)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("NOTE_EVENT");

                entity.Property(e => e.NoteText)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("NOTE_TEXT");

                entity.Property(e => e.Style)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("STYLE")
                    .IsFixedLength();

                entity.Property(e => e.Tstamp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TSTAMP");

                entity.Property(e => e.Type)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("TYPE");

                entity.Property(e => e.Typeflag)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TYPEFLAG");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("USERID");
            });

            modelBuilder.HasSequence("DBOBJECTID_SEQUENCE").IncrementsBy(50);

            modelBuilder.HasSequence("HIBERNATE_SEQUENCE");

            modelBuilder.HasSequence("SQASYNC_SERVICE");

            modelBuilder.HasSequence("SQDLTCOMPONENTS");

            modelBuilder.HasSequence("SQJOBCONTROL");

            modelBuilder.HasSequence("SQSTEPCONTROL");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
