// Copyright (c) 2014-2024 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wangkanai.Nation.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Models.Country>
{
	public void Configure(EntityTypeBuilder<Models.Country> builder)
	{
		builder.Property(x => x.Iso)
		       .HasMaxLength(2)
		       .IsRequired();

		builder.Property(x => x.Name)
		       .HasMaxLength(100)
		       .IsRequired();

		builder.Property(x => x.Native)
		       .HasMaxLength(100)
		       .IsUnicode()
		       .IsRequired();

		builder.Property(x => x.Population);
	}
}
