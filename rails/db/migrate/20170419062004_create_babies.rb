class CreateBabies < ActiveRecord::Migration[5.0]
  def change
    create_table :babies do |t|

      t.string :nota_type

      t.integer :team_1
      t.integer :team_2
      t.integer :team_3
      t.integer :team_4

      t.string :start_status

      t.boolean :start_1, default: false
      t.boolean :start_2, default: false
      t.boolean :start_3, default: false
      t.boolean :start_4, default: false
      
      t.timestamps
    end
  end
end
