using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject;

public partial class NhaappContext : DbContext
{
    public NhaappContext()
    {
    }

    public NhaappContext(DbContextOptions<NhaappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<Match> Matches { get; set; }

    public virtual DbSet<MatchResult> MatchResults { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayingPosition> PlayingPositions { get; set; }

    public virtual DbSet<Ranking> Rankings { get; set; }

    public virtual DbSet<Rate> Rates { get; set; }

    public virtual DbSet<Referee> Referees { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Stadium> Stadia { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\THANHLONG;database=NHAapp;Integrated security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("Account");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");

            entity.HasOne(d => d.Club).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.ClubId)
                .HasConstraintName("FK_Account_Club");
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.ToTable("Card");

            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.CardTime).HasColumnName("card_time");
            entity.Property(e => e.CardType).HasColumnName("card_type");
            entity.Property(e => e.MatchId).HasColumnName("match_id");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");

            entity.HasOne(d => d.Match).WithMany(p => p.Cards)
                .HasForeignKey(d => d.MatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Card_Match");

            entity.HasOne(d => d.Player).WithMany(p => p.Cards)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Card_Player");
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.ToTable("Club");

            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(50)
                .HasColumnName("logo_url");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.StadiumId).HasColumnName("stadium_id");
            entity.Property(e => e.YearCreated)
                .HasMaxLength(4)
                .HasColumnName("year_created");

            entity.HasOne(d => d.Country).WithMany(p => p.Clubs)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Club_Country");

            entity.HasOne(d => d.Stadium).WithMany(p => p.Clubs)
                .HasForeignKey(d => d.StadiumId)
                .HasConstraintName("FK_Club_Stadiun");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ShortName)
                .HasMaxLength(50)
                .HasColumnName("short_name");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK_Feedback_1");

            entity.ToTable("Feedback");

            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .HasColumnName("content");
            entity.Property(e => e.Problem)
                .HasMaxLength(50)
                .HasColumnName("problem");
            entity.Property(e => e.RateId).HasColumnName("rateId");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Rate).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.RateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_Rate");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.ToTable("Goal");

            entity.Property(e => e.GoalId).HasColumnName("goal_id");
            entity.Property(e => e.GoalTime).HasColumnName("goal_time");
            entity.Property(e => e.MatchId).HasColumnName("match_id");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");

            entity.HasOne(d => d.Match).WithMany(p => p.Goals)
                .HasForeignKey(d => d.MatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Goal_Match");

            entity.HasOne(d => d.Player).WithMany(p => p.Goals)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Goal_Player");
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.MatchId).HasName("PK_Match_1");

            entity.ToTable("Match");

            entity.Property(e => e.MatchId).HasColumnName("match_id");
            entity.Property(e => e.GuestId).HasColumnName("guest_id");
            entity.Property(e => e.HostId).HasColumnName("host_id");
            entity.Property(e => e.PlayDate)
                .HasColumnType("datetime")
                .HasColumnName("play_date");
            entity.Property(e => e.PlayStage)
                .HasMaxLength(50)
                .HasColumnName("play_stage");
            entity.Property(e => e.RefereeId).HasColumnName("referee_id");
            entity.Property(e => e.TourseasonId).HasColumnName("tourseason_id");
            entity.Property(e => e.VenueId).HasColumnName("venue_id");

            entity.HasOne(d => d.Guest).WithMany(p => p.MatchGuests)
                .HasForeignKey(d => d.GuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Match_Club1");

            entity.HasOne(d => d.Host).WithMany(p => p.MatchHosts)
                .HasForeignKey(d => d.HostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Match_Club");

            entity.HasOne(d => d.Referee).WithMany(p => p.Matches)
                .HasForeignKey(d => d.RefereeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Match_Referee");

            entity.HasOne(d => d.Venue).WithMany(p => p.Matches)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("FK_Match_Venue");
        });

        modelBuilder.Entity<MatchResult>(entity =>
        {
            entity.HasKey(e => new { e.MatchId, e.ClubId });

            entity.ToTable("Match_Result");

            entity.Property(e => e.MatchId).HasColumnName("match_id");
            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.Control).HasColumnName("control");
            entity.Property(e => e.Corners).HasColumnName("corners");
            entity.Property(e => e.Fouls).HasColumnName("fouls");
            entity.Property(e => e.GoalScore).HasColumnName("goal_score");
            entity.Property(e => e.Offsides).HasColumnName("offsides");
            entity.Property(e => e.Ontarget).HasColumnName("ontarget");
            entity.Property(e => e.PlayStage)
                .HasMaxLength(50)
                .HasColumnName("play_stage");
            entity.Property(e => e.Shots).HasColumnName("shots");
            entity.Property(e => e.WinLose)
                .HasMaxLength(50)
                .HasColumnName("win_lose");

            entity.HasOne(d => d.Club).WithMany(p => p.MatchResults)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Match_Result_Club");

            entity.HasOne(d => d.Match).WithMany(p => p.MatchResults)
                .HasForeignKey(d => d.MatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Match_Result_Match");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.ToTable("Player");

            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Dob)
                .HasMaxLength(50)
                .HasColumnName("dob");
            entity.Property(e => e.Height)
                .HasMaxLength(50)
                .HasColumnName("height");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PositionId)
                .HasMaxLength(50)
                .HasColumnName("position_id");
            entity.Property(e => e.Weight)
                .HasMaxLength(50)
                .HasColumnName("weight");

            entity.HasOne(d => d.Position).WithMany(p => p.Players)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK_Player_Playing_Position");
        });

        modelBuilder.Entity<PlayingPosition>(entity =>
        {
            entity.HasKey(e => e.PositionId);

            entity.ToTable("Playing_Position");

            entity.Property(e => e.PositionId)
                .HasMaxLength(50)
                .HasColumnName("position_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Ranking>(entity =>
        {
            entity.HasKey(e => e.ClubId);

            entity.ToTable("Ranking");

            entity.Property(e => e.ClubId)
                .ValueGeneratedNever()
                .HasColumnName("club_id");
            entity.Property(e => e.ClubName)
                .HasMaxLength(50)
                .HasColumnName("club_name");
            entity.Property(e => e.Drawn).HasColumnName("drawn");
            entity.Property(e => e.GoalDifference).HasColumnName("goal_difference");
            entity.Property(e => e.Lost).HasColumnName("lost");
            entity.Property(e => e.MatchPlayed).HasColumnName("match_played");
            entity.Property(e => e.Won).HasColumnName("won");

            entity.HasOne(d => d.Club).WithOne(p => p.Ranking)
                .HasForeignKey<Ranking>(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ranking_Club1");
        });

        modelBuilder.Entity<Rate>(entity =>
        {
            entity.ToTable("Rate");

            entity.Property(e => e.RateId)
                .ValueGeneratedNever()
                .HasColumnName("rateId");
            entity.Property(e => e.RateName)
                .HasMaxLength(50)
                .HasColumnName("rateName");
        });

        modelBuilder.Entity<Referee>(entity =>
        {
            entity.ToTable("Referee");

            entity.Property(e => e.RefereeId).HasColumnName("referee_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("dob");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .HasColumnName("image");
            entity.Property(e => e.RefereeName)
                .HasMaxLength(50)
                .HasColumnName("referee_name");
            entity.Property(e => e.YearStarted).HasColumnName("year_started");

            entity.HasOne(d => d.Country).WithMany(p => p.Referees)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Referee_Country");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");

            entity.HasMany(d => d.Usernames).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "RoleAccount",
                    r => r.HasOne<Account>().WithMany()
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Role_Account_Account"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Role_Account_Role"),
                    j =>
                    {
                        j.HasKey("RoleId", "Username");
                        j.ToTable("Role_Account");
                        j.IndexerProperty<int>("RoleId").HasColumnName("role_id");
                        j.IndexerProperty<string>("Username")
                            .HasMaxLength(50)
                            .HasColumnName("username");
                    });
        });

        modelBuilder.Entity<Stadium>(entity =>
        {
            entity.HasKey(e => e.StadiumId).HasName("PK_Stadiun");

            entity.ToTable("Stadium");

            entity.Property(e => e.StadiumId).HasColumnName("stadium_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => new { e.PlayerId, e.MatchId });

            entity.ToTable("Team");

            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.MatchId).HasColumnName("match_id");
            entity.Property(e => e.Starting).HasColumnName("starting");

            entity.HasOne(d => d.Match).WithMany(p => p.Teams)
                .HasForeignKey(d => d.MatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Team_Match");

            entity.HasOne(d => d.Player).WithMany(p => p.Teams)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Team_Player");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.ToTable("Venue");

            entity.Property(e => e.VenueId).HasColumnName("venue_id");
            entity.Property(e => e.AudienceCapacity).HasColumnName("audience_capacity");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
