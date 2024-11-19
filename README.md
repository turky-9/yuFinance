# yuFinance
作成当初、ドメイン駆動的な設計をしたかったみたい  
あとイミュータブルを基本にしたかったみたい

## 各クラス
- app
    各業務を表す
- result
    結果
    - success
        成功を表すクラス
    - failed
        失敗を表すクラス
- context
    マスタとトランザクション
    - builder
        contextの読込
    - storer
        contextの保存
- model
    モデル