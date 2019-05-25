# TDIN-2

* Callbacks: 

- Warehouse: Adicionar novo request à lista de requests do form (WarehouseClient); Atualizar o estado do request (passa a Ready quando clicado) para que possamos ter mais do que um cliente/form abertos na warehouse (todos serão atualizados).

- Store: Atualizar o estado das Orders (DISPATCH_WILL_OCCUR quando a warehouse notifica a store e DISPATCHED quando o empregado clica numa order); Adicionar nova order a lista quando ela é criada tanto no form da store comono website (os multiplos StoreClientForm que forem abertos estarão sempre atualizados/de acordo com a DB do StoreService).

## TODO

- Callback na criação de users na store