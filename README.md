# Criando Migrations

Para acompanhar as mudanças feitas no modelo de dados e manter a sincronia do modelo com o banco de dados o EF Core oferece o 
recurso Migrations ou Migrações que permite atualizar de forma incremental o esquema do banco de dados e assim mantê-lo 
sincronizado com o modelo de dados do seu projeto preservando os dados existentes.

# Comandos 
Usar as ferramentas no Visual Studio na janela do Package Manager Console (Windows)

> add-migration MigracaoInicial

O projeto será compilado e o arquivo de script gerado conforme abaixo:
```C#
namespace learn_migration.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_genero",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    genero = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_genero", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_instituicao",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_instituicao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_jogador",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    sobrenome = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    data_nasc = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_jogador", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_inscrito",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    jogador = table.Column<int>(type: "integer", nullable: false),
                    instituicao = table.Column<int>(type: "integer", nullable: false),
                    data_pub = table.Column<DateOnly>(type: "date", nullable: true),
                    genero = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_inscrito", x => x.id);
                    table.ForeignKey(
                        name: "tb_inscrito_genero_fkey",
                        column: x => x.genero,
                        principalTable: "tb_genero",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "tb_inscrito_instituicao_fkey",
                        column: x => x.instituicao,
                        principalTable: "tb_instituicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "tb_inscrito_jogador_fkey",
                        column: x => x.jogador,
                        principalTable: "tb_jogador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "tb_genero_genero_key",
                table: "tb_genero",
                column: "genero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_inscrito_genero",
                table: "tb_inscrito",
                column: "genero");

            migrationBuilder.CreateIndex(
                name: "IX_tb_inscrito_instituicao",
                table: "tb_inscrito",
                column: "instituicao");

            migrationBuilder.CreateIndex(
                name: "IX_tb_inscrito_jogador",
                table: "tb_inscrito",
                column: "jogador");

            migrationBuilder.CreateIndex(
                name: "tb_instituicao_nome_key",
                table: "tb_instituicao",
                column: "nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_inscrito");

            migrationBuilder.DropTable(
                name: "tb_genero");

            migrationBuilder.DropTable(
                name: "tb_instituicao");

            migrationBuilder.DropTable(
                name: "tb_jogador");
        }
    }
}
```

Temos aqui a classe MigracaoInicial que herda  de **Migration** e define dois métodos : **Up** e **Down**.
> **UP** Aplica o script 
> **Down** Reverte a aplicação feita

# Aplicando a migração

Depois de criar nossa migração com sucesso, precisamos aplicá-la para que as alterações entrem em vigor no banco de dados.

> update-database

# Incluir/Alterar/Deletar Propriedades na entidade (Jogador)

Vamos incluir a propriedade **MAE** na entidade **Jogador**

```C#
namespace learn_migration.Infrastructure.DataModels
{
    public partial class TbJogador
    {
        public TbJogador()
        {
            TbInscritos = new HashSet<TbInscrito>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public string Mae { get; set; } = null!;
        public DateOnly? DataNasc { get; set; }

        public virtual ICollection<TbInscrito> TbInscritos { get; set; }
    }
}
```
> add-migration tb_jogador_Mae

O projeto será compilado e o arquivo de script gerado conforme abaixo:

```C#
namespace learn_migration.Migrations
{
    public partial class tb_jogador_Mae : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mae",
                table: "tb_jogador",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mae",
                table: "tb_jogador");
        }
    }
}

```

Depois de criar nossa migração com sucesso, precisamos aplicá-la para que as alterações entrem em vigor no banco de dados.

> update-database






