using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Models.Entites;

namespace TodoList.Models.Configurations;


public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> category)
    { //Категория имеет несколько TodoList, c одной категорией(Category) по внешнему ключу (CategoryId)
        category.HasMany(x => x.Todoes)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}
