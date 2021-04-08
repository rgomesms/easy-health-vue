

let k = [
    { "CEP": "30421790", "logradouro": "Beco Realino", "bairro": "Ventosa", "cidade": "Belo Horizonte", "estado": "MG" },
    { "CEP": "31255056", "logradouro": "Rua São Caetano", "bairro": "São Francisco", "cidade": "Belo Horizonte", "estado": "MG" },
    { "CEP": "31530430", "logradouro": "Rua Doutor Alberto Cambraia de Abreu", "bairro": "Santa Mônica", "cidade": "Belo Horizonte", "estado": "MG" },
    { "CEP": "30421615", "logradouro": "Beco Marilinha", "bairro": "Ventosa", "cidade": "Belo Horizonte", "estado": "MG" },
    { "CEP": "30880210", "logradouro": "Rua Homero", "bairro": "Glória", "cidade": "Belo Horizonte", "estado": "MG" },
    { "CEP": "30626200", "logradouro": "Rua Mauro José Brito", "bairro": "Brasil Industrial (Barreiro)", "cidade": "Belo Horizonte", "estado": "MG" }
]
let inserts = [];
k.forEach(function (d) {
    inserts.push(`insert into \`Enderecos\` values('${d.CEP}','${d.logradouro}','${d.bairro}','${d.cidade}','${d.estado}');`)
})


console.log(inserts);


