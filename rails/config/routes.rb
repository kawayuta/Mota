Rails.application.routes.draw do
  resources :data
  resources :babies
  # For details on the DSL available within this file, see http://guides.rubyonrails.org/routing.html



 root to: 'babies#index'

end
